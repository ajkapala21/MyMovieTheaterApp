using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MovieTheater.Dtos;
using MovieTheater.Models;

namespace MovieTheater.Controllers.API
{
    public class ViewingsController : ApiController
    {
        private ApplicationDbContext _context;

        public ViewingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [ActionName("GetViewingsForMovie")]
        public IEnumerable<ViewingDto> GetViewingsForMovie(int id)
        {
            var viewingsQuery = _context.Viewings
                .Where(v => v.MovieId == id);

            return viewingsQuery
                .ToList()
                .Select(Mapper.Map<Viewing, ViewingDto>);
        }

        public IEnumerable<ViewingDto> GetViewings(string query = null)
        {
            var viewingsQuery = _context.Viewings.Where(v => true);

            if (!String.IsNullOrWhiteSpace(query))
                viewingsQuery = viewingsQuery.Where(v => v.Name.Contains(query));

            return viewingsQuery
                .ToList()
                .Select(Mapper.Map<Viewing, ViewingDto>);
        }

        public IHttpActionResult GetViewing(int id)
        {
            var viewings = _context.Viewings.SingleOrDefault(v => v.Id == id);

            if (viewings == null)
                return NotFound();

            return Ok(Mapper.Map<Viewing, ViewingDto>(viewings));
        }

        [HttpPost]
        //[Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateViewing(ViewingDto viewingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var viewing = Mapper.Map<ViewingDto, Viewing>(viewingDto);
            _context.Viewings.Add(viewing);

            _context.SaveChanges();

            viewingDto.Id = viewing.Id;
            return Created(new Uri(Request.RequestUri + "/" + viewing.Id), viewingDto);
        }

        [HttpPut]
        //[Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateViewing(int id, ViewingDto viewingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var viewingInDb = _context.Viewings.SingleOrDefault(v => v.Id == id);

            if (viewingInDb == null)
            {
                return NotFound();
            }
            Mapper.Map(viewingDto, viewingInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        //[Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteViewing(int id)
        {
            var viewingInDb = _context.Viewings.SingleOrDefault(v => v.Id == id);

            if (viewingInDb == null)
                return NotFound();

            _context.Viewings.Remove(viewingInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
