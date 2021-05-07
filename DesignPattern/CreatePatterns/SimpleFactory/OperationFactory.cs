namespace DesignPattern.CreatePatterns.SimpleFactory
{
    public class OperationFactory
    {
        public enum OperationType
        {
            ADD = '+',
            SUB = '-',
            DIV = '/',
            MUL = '*'
        }

        public static Operation CreateOperation(OperationType type_)
        {
            Operation operation = null;

            switch (type_)
            {
                case OperationType.ADD:
                    operation = new OperationAdd();
                    break;
                
                case OperationType.SUB:
                    operation = new OperationSub();
                    break;
                
                case OperationType.DIV:
                    operation = new OperationDiv();
                    break;
                
                case OperationType.MUL:
                    operation = new OperationMul();
                    break;
            }

            return operation;
        }
    }
}