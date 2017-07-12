namespace MessageDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Message : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        messageID = c.Int(nullable: false, identity: true),
                        messages = c.String(),
                        messagSenderID = c.String(),
                        messageRecierID = c.String(),
                        errMessages = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        message_messageID = c.Int(),
                        messageDataAccess_messageID = c.Int(),
                    })
                .PrimaryKey(t => t.messageID)
                .ForeignKey("dbo.Message", t => t.message_messageID)
                .ForeignKey("dbo.Message", t => t.messageDataAccess_messageID)
                .Index(t => t.message_messageID)
                .Index(t => t.messageDataAccess_messageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Message", "messageDataAccess_messageID", "dbo.Message");
            DropForeignKey("dbo.Message", "message_messageID", "dbo.Message");
            DropIndex("dbo.Message", new[] { "messageDataAccess_messageID" });
            DropIndex("dbo.Message", new[] { "message_messageID" });
            DropTable("dbo.Message");
        }
    }
}
