namespace LabExam
{
    interface IPrinterManager
    {
        void Add(BasePrinter basePrinter);
        void Print(BasePrinter basePrinter, ILogger logger);
    }
}
