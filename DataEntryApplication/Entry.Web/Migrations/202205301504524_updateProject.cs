namespace Entry.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProject : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Projects");
            AlterColumn("dbo.Projects", "ProjectId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Projects", "ProjectId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Projects");
            AlterColumn("dbo.Projects", "ProjectId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Projects", "ProjectID");
        }
    }
}
