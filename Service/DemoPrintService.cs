namespace BasicHangfire.Demo.Service
{
    public class DemoPrintService : IDemoPrintService
    {
        public DemoPrintService()
        {
            
        }

        public void Print()
        {
            Console.WriteLine("Hangfire recurring job executed.");
        }
    }
}
