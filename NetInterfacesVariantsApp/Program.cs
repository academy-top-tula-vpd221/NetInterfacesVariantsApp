//IMessanger<EmailMessage> outlook = new EmailMessanger();
//IMessanger<Message> bat = new EmailMessanger();
//Message message1 = bat.CreateMessage("Hello");
//Console.WriteLine(message1.Text);

//bat = outlook;

//IMessanger<Message> messanger = new SmsMessanger();
//IMessanger<SmsMessage> smsMessanger = messanger;
//smsMessanger.Send(new SmsMessage("Hello", "123456789"));

//IMessanger<SmsMessage> messanger2 = new SmsMessanger();
//messanger2.Send(new SmsMessage("Hello", "123456789"));


IMessanger<EmailMessage, Message> messanger = new MyMessanger();
Message message = messanger.CreateMessage("Hello world");
Console.WriteLine(message.Text);
messanger.Send(new EmailMessage("hello", "hello"));




class Message
{
    public string Text { get; set; }
    public Message(string text) { this.Text = text; }
}

class EmailMessage : Message
{
    public string Subject { get; set; }
    public EmailMessage(string text, string subject) : base(text)
    {
        Subject = subject;
    }
}
class SmsMessage : Message
{
    public string Number { get; set; }
    public SmsMessage(string text, string number) : base(text)
    {
        Number = number;
    }
}


//interface IMessanger<out T>
//{
//    T CreateMessage(string message);
//}

//class EmailMessanger : IMessanger<EmailMessage>
//{
//    public EmailMessage CreateMessage(string message)
//    {
//        return new EmailMessage(message, "subject");
//    }
//}

//interface IMessanger<in T>
//{
//    void Send(T message);
//}

//class SmsMessanger : IMessanger<Message>
//{
//    public void Send(Message message)
//    {
//        Console.WriteLine($"Send message {message.Text}");
//    }
//}

interface IMessanger<in T, out U>
{
    void Send(T message);
    U CreateMessage(string text);
}

class MyMessanger : IMessanger<Message, EmailMessage>
{
    public EmailMessage CreateMessage(string text)
    {
        return new EmailMessage(text, "hello");
    }

    public void Send(Message message)
    {
        Console.WriteLine($"Send message {message.Text}");
    }
}