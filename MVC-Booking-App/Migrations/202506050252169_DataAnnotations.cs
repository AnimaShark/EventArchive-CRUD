namespace MVC_Booking_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RSVPs", "EventName", c => c.String(maxLength: 60));
            AlterColumn("dbo.RSVPs", "Genre", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RSVPs", "Genre", c => c.String());
            AlterColumn("dbo.RSVPs", "EventName", c => c.String());
        }
    }
}
