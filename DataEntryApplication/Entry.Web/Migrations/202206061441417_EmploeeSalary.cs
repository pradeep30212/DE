namespace Entry.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmploeeSalary : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeSalaries",
                c => new
                    {
                        EmployeeSalaryId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        MonthId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Salary = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeSalaryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeSalaries");
        }
    }
}
