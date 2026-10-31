namespace EntityProject.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Column_Id_To_UserId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "Id", newName: "UserId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Users", name: "UserId", newName: "Id");
        }
    }
}
