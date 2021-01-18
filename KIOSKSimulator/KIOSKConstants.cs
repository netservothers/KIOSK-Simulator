using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKSimulator
{
    public class KIOSKConstants
    {
        public const byte ControlByte_Ack = 0x06;
        public const byte ControlByte_Comma = 0x2C;
        public const byte ControlByte_Dle = 0x10;
        public const byte ControlByte_Enq = 0x05;
        public const byte ControlByte_Etx = 3;
        public const byte ControlByte_FieldSeparator = 0x1C;
        public const byte ControlByte_Nack = 0x15;
        public const byte ControlByte_Stx = 2;

        public const char ControlChar_Ack = (char)ControlByte_Ack;
        public const char ControlChar_Comma = (char)ControlByte_Comma;
        public const char ControlChar_Dle = (char)ControlByte_Dle;
        public const char ControlChar_Enq = (char)ControlByte_Enq;
        public const char ControlChar_Etx = (char)ControlByte_Etx;
        public const char ControlChar_FieldSeparator = (char)ControlByte_FieldSeparator;
        public const char ControlChar_Nack = (char)ControlByte_Nack;
        public const char ControlChar_Stx = (char)ControlByte_Stx;

        public static readonly char[] ControlChars = new char[] { ControlChar_Ack, ControlChar_Comma, ControlChar_Dle, ControlChar_Enq, ControlChar_Etx, ControlChar_FieldSeparator, ControlChar_Nack, ControlChar_Stx };

        public const string MessageType_Purchase = "20";
        public const string MessageType_Void = "26";

        public const string FieldType_Amount = "40";
        public const string FieldType_AcquirerSelection = "74";
        public const string FieldType_InvoiceNumber = "65";

        public const int Timeout_ReceiveAck_Milliseconds = 3000;
        public const int Timeout_ReadResponse_Milliseconds = 60000;
        public const int Timeout_ClearInputBuffer_Milliseconds = 100;

        public const int ReadDelay_Milliseconds = 100;
        public const int RetryDelay_Milliseconds = 100;
        public const int Max_ConnectionRetries = 3;

        public const int MaxBufferSize_Read = 5500;

        public const int MaxNackRetries = 3;

        public const int ValidMesage_MinBytes = 5;

        public const string Response_Yes = "YES";
        public const string Response_No = "NO";

        public static readonly IReadOnlyList<string> DefaultQueryResponses = (new List<string>() { Response_Yes, Response_No }).AsReadOnly();
    }
}
