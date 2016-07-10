namespace Lucasweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Sounds",
                c => new
                    {
                        SoundID = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        type = c.String(),
                        Name = c.String(),
                        OwnerName = c.String(),
                        UploadTime = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.SoundID);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    UserId = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: true),
                    LastName = c.String(nullable: true),
                    UserName = c.String(nullable: false),
                    Email = c.String(),
                    UniqueEncryptPassword = c.String()
                }).PrimaryKey(t => t.UserId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Sounds");
            DropTable("dbo.Users");
        }
    }
}
