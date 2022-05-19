namespace DataEntry.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeSalaryCreation : DbMigration
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
                        YearId = c.Int(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.EmployeeSalaryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeSalaries");
        }
    }
}
