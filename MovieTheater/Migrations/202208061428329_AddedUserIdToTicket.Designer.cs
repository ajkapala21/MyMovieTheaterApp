// <auto-generated />
namespace MovieTheater.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class AddedUserIdToTicket : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddedUserIdToTicket));
        
        string IMigrationMetadata.Id
        {
            get { return "202208061428329_AddedUserIdToTicket"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}