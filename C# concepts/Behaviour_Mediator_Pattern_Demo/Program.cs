namespace Behaviour_Mediator_Pattern_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IChatMediator chatRoom = new ChatRoom();

            User Tom = new User("Tom",chatRoom);
            User Jerry = new User("Jerry", chatRoom);
            User Tyke = new User("Tyke" ,chatRoom);

            chatRoom.AddUser(Tom);
            chatRoom.AddUser(Jerry);
            chatRoom.AddUser(Tyke);
            Tom.Send("Hello everyone");
            Jerry.Send("Hi from Jerry");

            Console.ReadLine();
        }
    }
}
