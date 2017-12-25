using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class StringTools
    {
        /// <summary>
        /// 解碼 CDMA 的 User Data ( Octet )
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        static public string Decode_CDMA_UserData(string raw)
        {



            #region New
            {
                // 原資料從 第3個 byte 開始 , 向左移3個 bits 進第 2 個 byte 右半邊
                // 01 A2 C262500808080000000CF66BA862467EF0C001003242775D5E1F0370F061957BC5AD5CA59C97146D4BDFDFCE70FB9F0027539338
                // ......右邊開始
                // 解開時 , 從第 2 個 byte 右半邊 , 右移 3 個byte
                
                // string t = raw.Substring(2);
                byte[] bs = HexStringToByteArray(raw);//"ABCDEFAB");//MirrorByteNumber(raw));
                byte[] rs = new byte[bs.Length-2];

                int startRight = 2; // 從 bs 第 3 個 byte 開始
                for (int i = 0; i < rs.Length; i++)
                {
                    byte bRight = (byte)(bs[startRight + i] >> 3);
                    byte bLeft  = (byte)(bs[startRight + i -1] << 5);
                    rs[i] = (byte)(bLeft | bRight);
                }

                string str = ByteArrayToHexString(rs).Replace(" ", "");
                //str = str.Substring(1) + str.Substring(0, 1);
                return str;

               
            }
            #endregion


            #region Old
            {
                // Before : 0818100BD80800080808000000007837FE8A872AEB88000805384000030800000004C041899199A1C1C1C1C081899199A1A9B1B9C1C981899199A1A9B010001C07922893C2E6DC7645EF0A43B54458D55A01DC2EF9FFF5B398CB169165FF0838A978F49701BB9731FEE5B9924ABC76AA46E889C19DC18462C607C461E9A00180
                // After  : 0302017B0100010101000000000F06FFD150E55D71000100A7080000610000000098083132333438383838103132333435363738393031323334353602000380F24512785CDB8EC8BDE14876A88B1AAB403B85DF3FFEB6731962D22CBFE107152F1E92E03772E63FDCB73249578ED548DD113833B8308C58C0F88C3D340030

                string t = raw.Substring(2);
                byte[] bs = HexStringToByteArray(t);//"ABCDEFAB");//MirrorByteNumber(raw));

                byte[] bs2 = new byte[bs.Length];
                int xx = bs.Length - 1;
                for (int i = 0; i < bs.Length; i++)
                {
                    byte a = (byte)(bs[i] << 1);
                    byte b = 0;
                    if (i != xx)
                    {
                        b = (byte)(bs[i + 1] >> 7);
                        bs2[i + 1] = (byte)(a | b);
                    }
                    else
                    {
                        // 處理最後一組
                        string s = raw.Substring(0, 2);
                        byte[] aa = HexStringToByteArray(s);

                        b = (byte)(aa[0] << 5);
                        b = (byte)(b >> 4);
                        a = (byte)(bs[0] >> 7);
                        bs2[0] = (byte)(a | b);


                        //b = (byte)(bs[0] >> 7);
                        //bs2[0] = (byte)(a | b);
                    }
                }

                string str = ByteArrayToHexString(bs2).Replace(" ", "");
                str = str.Substring(1) + str.Substring(0, 1);
                return str;
            }
            #endregion

        }


        static public string Encode_CDMA_USerData(string raw)
        {
            // Before : 0302017B0100010101000000000F06FFD150E55D71000100A7080000610000000098083132333438383838103132333435363738393031323334353602000380F24512785CDB8EC8BDE14876A88B1AAB403B85DF3FFEB6731962D22CBFE107152F1E92E03772E63FDCB73249578ED548DD113833B8308C58C0F88C3D340030
            // After  : 0818100BD80800080808000000007837FE8A872AEB88000805384000030800000004C041899199A1C1C1C1C081899199A1A9B1B9C1C981899199A1A9B010001C07922893C2E6DC7645EF0A43B54458D55A01DC2EF9FFF5B398CB169165FF0838A978F49701BB9731FEE5B9924ABC76AA46E889C19DC18462C607C461E9A00180
            byte[] bs = HexStringToByteArray(raw); 

            byte[] bs2 = new byte[bs.Length];
            int xx = bs.Length - 1;
            byte bLeft = 0;
            for (int i = 0; i < bs.Length; i++)
            {
                byte a = (byte)(bs[i] << 3);
                if (i == 0)
                {
                    bLeft = (byte)(a>>3);
                }

                byte b = 0;
                if (i != xx)
                {
                    b = (byte)(bs[i + 1] >> 5);
                    bs2[i+1] = (byte)(a | b);
                }
                else
                {
                    // 處理最後一組
                    //b = (byte)(bs[0] >> 7);
                    //bs2[0] = (byte)(a|bLeft);
                    bs2[0] = (byte)(a);
                }
            }

            string str = ByteArrayToHexString(bs2).Replace(" ", "");
            str = str.Substring(2) + str.Substring(0,2);
            return str;
        }

        /// <summary>
        /// 將每個 byte 左右位對調 , 如有奇數最後以 F 補足
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        static public string MirrorByteNumber(string hex)
        {
            // 00 12 3  ==> 00 21 F3
            string result = "";
            int count = hex.Length / 2 + hex.Length % 2;

            for (int i = 0; i < count; i++)
            {
                string temp = "";
                //int len = 2;
                bool bFlag = false;
                if (i == (count - 1)) // 最後一組
                {
                    if (hex.Length % 2 == 1) // 且只有一個數字的話.補上 F.
                    {
                        bFlag = true;
                    }
                }

                // 取得這一組的暫時文字 , 及是否需要補 F  
                if (bFlag)
                {
                    temp = hex.Substring(i * 2) + "F";
                }
                else
                {
                    temp = hex.Substring(i * 2, 2);
                }

                // 對調.
                result += temp.Substring(1, 1) + temp.Substring(0, 1);

            }

            return result;
        }

        /// <summary>
        /// 將電話號碼轉換成 TLV-Address
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static public string PhoneNumber2TLV(string number)
        {
            string address = MirrorByteNumber(number);
            address = address.Replace("*", "A");
            address = address.Replace("#", "B");
            address = address.Replace("+", "C");
            return address;
        }


        static public string Convert2ADNHex(string str)
        {
            string rs = "";
            for (int i = 0; i < str.Length / 2; i++)
            {
                string s = str.Substring(i * 2 + 1, 1) + str.Substring(i*2,1);
                rs += s;
            }

            // 補 奇數 最後一個字
            if (str.Length % 2 == 1)
            {
                rs += "F" + str.Substring(str.Length-1);
            }

            return rs;
        }

        // 返回 BCD Hex String
        static public string Convert2BCDHex(string str)
        {
            if (str.Length % 2 == 1)
                return (str + "F");

            return str;
        }

        // 返回 BCD Hex String
        static public string Convert2BCDHex(byte [] bs)
        {
            string str = "";
            for (int i = 0; i < bs.Length; i++)
            {
                str += bs[i].ToString("X2");
            }
            
            return Convert2BCDHex(str);
        }


        static public string UCS22Hex(string ucs2)
        {
            try
            {
                byte[] bs = Encoding.Unicode.GetBytes(ucs2);

                // 進行上下 byte 對調
                for (int i = 0; i < bs.Length / 2; i++)
                {
                    byte temp = bs[i * 2];
                    bs[i * 2] = bs[i * 2 + 1];
                    bs[i * 2 + 1] = temp;
                }

                StringBuilder hex = new StringBuilder();
                for (int i = 0; i < bs.Length; i++)
                {
                    hex.Append(bs[i].ToString("X02"));
                }
                return hex.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message + "\r\n" + ex.StackTrace;
            }
        }

        /// <summary>
        /// 將 Ascii 字串 轉換為 Hex 字串
        /// </summary>
        /// <param name="asciiString"></param>
        /// <returns></returns>
        static public string Ascii2Hex(string asciiString )
        {
            try
            {
                byte[] ls_bytes = Encoding.ASCII.GetBytes(asciiString);
                StringBuilder hex = new StringBuilder();
                for (int i = 0; i < ls_bytes.Length; i++)
                {
                    hex.Append(ls_bytes[i].ToString("X02"));
                }
                return hex.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message + "\r\n" + ex.StackTrace;
            }
        }


        static public string RestoreNewLine(string str)
        {
            return str.Replace("\\r\\n", "\r\n");
        }

        /// <summary>
        /// 將 Hex 字串 轉換為 Ascii 字串
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        static public string Hex2Ascii(string hexString)
        {
            //byte [] bs = Enumerable.Range(0, hex.Length)
            //    .Where(x => x % 2 == 0)
            //    .Select(x => Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
            try
            {
                int count = hexString.Length / 2;
                byte[] bs = new byte[count];
                for (int i = 0; i < count; i++)
                {
                    bs[i] = byte.Parse(hexString.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
                }

                string hex = Encoding.ASCII.GetString(bs);
                return hex;
            }
            catch (Exception ex)
            {
                return ex.Message + "\r\n" + ex.StackTrace;
            }
        }


        /// <summary>
        /// 補 Hex 字串 - 補在左邊 , 並讓所有字數為 count 的數量
        /// ex: PadLeft("31323334","FF" , 8) ==> "FFFFFFFF31323334"
        /// </summary>
        /// <param name="sourceHexString"></param>
        /// <param name="padHex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        static public string PadLeft(string sourceHexString, string padHex, int count)
        {
            string hex = sourceHexString;
            int addCount = count - hex.Length / 2;
            for (int i = 0; i < addCount; i++)
            {
                hex = padHex + hex;
            }
            return hex;
        }


        /// <summary>
        /// 補 Hex 字串 - 補在右邊 , 並讓所有字數為 count 的數量
        /// ex: PadLeft("31323334","20" , 8) ==> "3132333420202020"
        /// </summary>
        /// <param name="sourceHexString"></param>
        /// <param name="padHex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        static public string PadRight(string sourceHexString, string padHex, int count)
        {
            string hex = sourceHexString;
            int addCount = count - hex.Length / 2;
            for (int i = 0; i < addCount; i++)
            {
                hex += padHex;
            }
            return hex;
 
        }

        /// <summary>
        /// 將 ASCII 字轉成 Hex , 並右邊 , 加入 Padding Rule , 補足設定文字的長度 , 及要補的 文字內容
        /// ex: Ascii2HexPadR("1234","FF" , 8) ==> "31323334FFFFFFFF"
        /// </summary>
        /// <param name="ascii"></param>
        /// <param name="padHex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        static public string Ascii2HexPadR(string ascii,string padHex,int count)
        {
            string hex = Ascii2Hex(ascii);
            string str = PadRight(hex, padHex, count);
            return str;
        }

        /// <summary>
        /// 將 ASCII 字轉成 Hex , 並左邊 , 加入 Padding Rule , 補足設定文字的長度 , 及要補的 文字內容
        /// ex: Ascii2HexPadR("1234","FF" , 8) ==> "FFFFFFFF31323334"
        /// </summary>
        /// <param name="ascii"></param>
        /// <param name="padHex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        static public string Ascii2HexPadL(string ascii, string padHex, int count)
        {
            string hex = Ascii2Hex(ascii);
            return PadLeft(hex, padHex, count);

        }



        static public string Hex2UCS2(string hexString)
        {
            try
            {
                string str = "";
                byte[] bs = new byte[hexString.Length / 2];
                for (int i = 0; i < hexString.Length / 2; i++)
                {
                    string s = hexString.Substring(i * 2, 2);
                    bs[i] = byte.Parse(s, System.Globalization.NumberStyles.HexNumber);
                }

                // 進行上下 byte 對調
                for (int i = 0; i < bs.Length / 2; i++)
                {
                    byte temp = bs[i * 2];
                    bs[i * 2] = bs[i * 2 + 1];
                    bs[i * 2 + 1] = temp;
                }


                str = Encoding.Unicode.GetString(bs);

                return str;
            }
            catch (Exception ex)
            {
                return ex.Message + "\r\n" + ex.StackTrace;
            }
        }

        /// <summary>
        /// 將檔案路徑裡一些禁用的字轉換為合法字元
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ConvertSpecialWordOfFileName(string fileName)
        {
            string result = fileName;
            string [] catchs   = {":" , "*" , "?" , "\"" , "<" ,  ">" , "|" };
            string [] converts = {"：", "＊" , "？" , "＂" , "＜" ,  "＞" , "｜" }; 
            for (int i=0;i<catchs.Length;i++)
            {
                result = result.Replace(catchs[i],converts[i]);
            }
            if (result.IndexOf("：") == 1) // D：\  ===> D:\
            {
                result = result.Substring(0, 1) + ":" + result.Substring(2);
            }
            return result;
        }


        public static String ShowHexString(String HexStringcodes)
        {
            int Ded = HexStringcodes.Length / 2;
            String TempString = HexStringcodes;
            String returncode = String.Format("Length = Decimal: {0} Hex: {1:X}\r\n", Ded, Ded);
            int fori = Ded / 16;
            if ((Ded % 16) != 0)
            {
                fori++;
                TempString = TempString.PadRight(((fori * 16) * 2), 'F');
                //TempString.PadRight((fori * 2), 'F');
            }
            fori = (TempString.Length / 2) / 16;
            returncode += String.Format("-Address--------------------Hexadecimal--------------------------ASCII------\r\n");
            returncode += String.Format("          00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F                   \r\n");
            for (int i = 0; i < fori; i++)
            {
                returncode += String.Format("{0}  {1}  {2}\r\n", String.Format("{0:X}", (i * 16)).PadLeft(8, '0'), AddSpacing(TempString.Substring((i * 32), 32), 2, 'F'), ShowAscii(TempString.Substring((i * 32), 32), 2));
            }
            returncode += String.Format("----------------------------------------------------------------------------\r\n");
            return returncode;
        }


        public static String AddSpacing(String StrTemp, int CharNo, Char PadCode)
        {
            String returncode = "";
            StrTemp = StrTemp.PadRight((StrTemp.Length + (StrTemp.Length % CharNo)), PadCode);
            for (int i = 0; i < StrTemp.Length; i += CharNo)
            {
                returncode += String.Format("{0} ", StrTemp.Substring(i, CharNo));
            }
            return returncode;
        }

        public static String ShowAscii(String InString, int ss)
        {
            int Length = 0;
            String ReturnString = "";
            string[] strlist = new string[InString.Length / ss];
            try
            {
                for (int i = 0; i < strlist.Length; i++)
                {
                    strlist[i] = InString.Substring((i * ss), ss);
                    Length = Convert.ToInt16(strlist[i], 16);
                    if ((Length <= 31) || (Length >= 127))
                    {
                        ReturnString += ".";
                    }
                    else
                    {
                        //將unicode轉為10進制整數，然後轉為char中文
                        ReturnString += (char)int.Parse(strlist[i], System.Globalization.NumberStyles.HexNumber);
                    }
                }
            }
            catch (FormatException ex)
            {
            //           ReturnString = ex.Message;
            System.Console.WriteLine(ex.Message);
            }
            return ReturnString;
        }


        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }


        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary>
        /// return result in specified length
        /// </summary>
        /// <param name="strHex"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        public static string hex2Bin(string strHex, int bit)
        {
            int decNumber = hex2Dec(strHex);
            return dec2Bin(decNumber).PadLeft(bit, '0');
        }
        /// <summary>
        /// return result in specified length
        /// </summary>
        /// <param name="val"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        public static string dec2Bin(int val, int bit)
        {
            return Convert.ToString(val, 2).PadLeft(bit, '0');
        }
        public static string hex2Bin(string strHex)
        {
            int decNumber = hex2Dec(strHex);
            return dec2Bin(decNumber);
        }
        public static string bin2Hex(string strBin)
        {
            int decNumber = bin2Dec(strBin);
            return dec2Hex(decNumber);
        }
        public static string dec2Hex(int val)
        {
            return val.ToString("X");
            //return Convert.ToString(val,16); 
        }
        public static int hex2Dec(string strHex)
        {
            return Convert.ToInt16(strHex, 16);
        }
        public static string dec2Bin(int val)
        {
            return Convert.ToString(val, 2);
        }
        public static int bin2Dec(string strBin)
        {
            return Convert.ToInt16(strBin, 2);
        }
        public static byte[] _Hex2Bin(string hex)
        {
            if ((hex == null) || (hex.Length < 1))
            {
                return new byte[0];
            }
            int num = hex.Length / 2;
            byte[] buffer = new byte[num];
            num *= 2;
            for (int i = 0; i < num; i++)
            {
                int num3 = int.Parse(hex.Substring(i, 2),System.Globalization.NumberStyles.HexNumber);
                buffer[i / 2] = (byte)num3;
                i++;
            }
            return buffer;
        }
        public static string Bin2Hex(byte[] binary)
        {
            StringBuilder builder = new StringBuilder();
            foreach (byte num in binary)
            {
                if (num > 15)
                {
                    builder.AppendFormat("{0:X}", num);
                }
                else
                {
                    builder.AppendFormat("0{0:X}", num);// 小於 15 就多加個 0
                }
            }
            return builder.ToString();
        }
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        /// <summary>
        /// 奇偶互換 (+F)
        /// </summary>
        /// <param name="str"??>要被轉換的字符串</param>
        /// <returns>轉換後的結果字符串</returns>
        public static string ParityChange(string str)
        {
            string result = string.Empty;
            if (str.Length % 2 != 0) //奇字符串補F
            {
                str += "F";
            }
            for (int i = 0; i < str.Length; i += 2) //奇偶互換
            {
                result += str[i + 1];
                result += str[i];
            }
            return result;
        }
        /// <summary>
        /// 判斷字符串中是否不含中文字符（是否是ASCII字符串）
        /// </summary>
        /// <param name="str"??>要判斷的字符串</param>
        /// <returns>bool值是ASCII字符串，返回True；否則false</returns>
        private static bool IsASCII(string str)
        {
            int strLen = str.Length;
            //字符串的字節數，字母佔1位，漢字佔2位,注意，一定要UTF8
            int byteLen = System.Text.Encoding.UTF8.GetBytes(str).Length;
            //字符數和字節數相等，則全部是ASCII碼字符；不相等則字節數大於字符數含有漢字字符
            return (strLen == byteLen);
        }
        /// <summary>
        /// 十六進製字符串轉二進製字節串
        /// </summary>
        /// <param name="hex">十六進製字符串</param>
        /// <returns>轉化得到的byte[]</returns>
        private static byte[] Hex2Bin(string hex)
        {
            byte[] bin = new byte[hex.Length / 2]; //結果字節串
            for (int i = 0; i < hex.Length; i += 2)
            {
                //兩個字符一組 轉化為一個字節
                bin[i / 2] = (byte)Convert.ToByte((hex[i].ToString() + hex[i + 1].ToString()), 16);
            }
            return bin;
        }
        public static byte[] PackH(string hex)
        {
            if ((hex.Length % 2) == 1) hex += '0';
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        public static string base64Encode(string data)
        {
            try
            {
                byte[] byte_data = new byte[data.Length];
                byte_data = System.Text.Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(byte_data);
                return encodedData;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string base64Decode(string data)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] byte_data = Convert.FromBase64String(data);
                int charCount = utf8Decode.GetCharCount(byte_data, 0, byte_data.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(byte_data, 0, byte_data.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    /*
        public static string Convert_8b_2_7b(string hex_8b)
        {
            string str = "";
            try
            {
                byte[] bs8b = HexStringToByteArray(hex_8b);
                byte[] bs7b = PduBitPackerDemo.PduBitPacker.PackBytes(bs8b);
                str = ByteArrayToHexString(bs7b).Replace(" ","");
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }
            return str;
        }


        public static string Convert_7b_2_8b(string hex_7b)
        {
            string str = "";
            try
            {
                byte[] bs7b = HexStringToByteArray(hex_7b);
                byte[] bs8b = PduBitPackerDemo.PduBitPacker.UnpackBytes(bs7b);
                str = ByteArrayToHexString(bs8b).Replace(" ", "");
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }
            return str;
        }
        */
    }

