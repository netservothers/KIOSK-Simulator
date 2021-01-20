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

        public const int Timeout_ReceiveAck_Milliseconds = 3000;
        public const int Timeout_ReadResponse_Milliseconds = 60000;
        public const int Timeout_ClearInputBuffer_Milliseconds = 100;

        public const int ReadDelay_Milliseconds = 100;
        public const int RetryDelay_Milliseconds = 100;
        public const int Max_ConnectionRetries = 3;

        public const int MaxBufferSize_Read = 5500;

        public const string SaleRequestActionCode = "A0";
        public const string VoidRequestActionCode = "A2";

        public const string SaleResponseActionCode = "A1";
        public const string VoidResponseActionCode = "A3";

        public const string HexaDecimalFormat = "X2";


        public const int MaxNackRetries = 3;

        public const int ValidMesage_MinBytes = 5;

        public const string Response_Yes = "YES";
        public const string Response_No = "NO";

        public const string KioskMessageHeader = "3E55";

        public static readonly IReadOnlyList<string> DefaultQueryResponses = (new List<string>() { Response_Yes, Response_No }).AsReadOnly();
    }

    public class KIOSKTags
    {
        public const string ReferenceNumber = "01";
        public const string DeveloperID = "02";
        public const string Amount = "03";
        public const string Description = "04";
        public const string TransactionID = "05";
        public const string ApprovalCode = "06";
        public const string CardType = "07";
        public const string ApplicationLabel = "08";
        public const string CardNo = "09";

        public const string TransactionDate = "11";
        public const string TransactionTime = "12";
        public const string TID = "13";
        public const string MID = "14";
        public const string BatchNo = "15";
        public const string InvoiceNo = "16";
        public const string RREFNo = "17";
        public const string TSI = "18";
        public const string TVR = "19";
        public const string EntType = "20";

        public const string ActionCode = "21";
        public const string ResponseCode = "22";
        public const string PaymentType = "23";
        public const string ProductType = "25";
        public const string AmountAuthorized = "26";

        public const string PrivateField = "31";
        public const string VoidType = "33";
        public const string NetworkSelection = "37";

        public const string EntryType = "3B";

        public const string CouponCode = "1A";
        public const string CardHolderName = "0A";
        public const string TraceNo = "0B";
        public const string TC = "0C";
        public const string AID = "0D";
        public const string CVMType = "0E";

        public static readonly List<string> Taglist = new List<string>() { ReferenceNumber, DeveloperID, Amount, Description, TransactionID, ApprovalCode, CardType, ApplicationLabel, CardNo, TransactionDate, TransactionTime, TID, MID, BatchNo, InvoiceNo, RREFNo, TSI, TVR, EntType, ActionCode, ResponseCode, PaymentType, ProductType, AmountAuthorized, PrivateField, VoidType, NetworkSelection, EntryType, CouponCode, CardHolderName, TraceNo, TC, AID, CVMType };
    }
}