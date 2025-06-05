namespace MVC_Booking_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketQuota : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RSVPs", "TicketQuota", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RSVPs", "TicketQuota", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
