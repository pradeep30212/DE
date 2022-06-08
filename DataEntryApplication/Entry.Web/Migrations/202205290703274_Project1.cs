namespace Entry.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Project1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Projects");
            AlterColumn("dbo.Projects", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Projects", "ProjectDuration", c => c.String());
            AddPrimaryKey("dbo.Projects", "ProjectID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Projects");
            AlterColumn("dbo.Projects", "ProjectDuration", c => c.Int(nullable: false));
            AlterColumn("dbo.Projects", "ProjectId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Projects", "ProjectID");
        }
    }
}
