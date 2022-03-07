using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTreinoCarlos.Utils
{
    public class Util
    {
        public static string toDateEN(string input, DateTime ndata = new DateTime())
        {
            try
            {
                if (input == "" || input == null)
                {
                    return null;


                }
                else
                {
                    ndata = new DateTime(int.Parse(input.Substring(6, 4)), int.Parse(input.Substring(3, 2)), int.Parse(input.Substring(0, 2)));
                    //CODE Month/Day/Year
                    string ret = string.Format("{1}/{2}/{0}", input.Substring(6, 4), input.Substring(3, 2), input.Substring(0, 2));
                    return ret;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Converte uma data string  MM\/DD\/YYYY em date
        /// </summary>
        /// <param name="DataEN">MM\/DD\/YYYY</param>
        /// <returns></returns>
        public static DateTime? ENtoDate(string DataEN)
        {
            try
            {

                if (DataEN == "" || DataEN == null)
                {
                    return null;
                }
                else
                {
                    DateTime ndata = new DateTime(int.Parse(DataEN.Substring(6, 4)), int.Parse(DataEN.Substring(0, 2)), int.Parse(DataEN.Substring(3, 2)));
                    return ndata;
                }
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public static DateTime? ENtoDate(string DataEN, string separator, string order_ymd = "012")
        {
            try
            {

                if (DataEN == "" || DataEN == null)
                {
                    return null;
                }
                else
                {
                    string[] dto = DataEN.Split(separator);
                    int y = int.Parse(order_ymd.Substring(0, 1));
                    int m = int.Parse(order_ymd.Substring(1, 1));
                    int d = int.Parse(order_ymd.Substring(2, 1));
                    DateTime ndata = new DateTime(int.Parse(dto[y]), int.Parse(dto[m]), int.Parse(dto[d]));
                    return ndata;
                }
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Converte data em PT-BR para um datetime
        /// </summary>
        /// <param name="DataPT">DD\/MM\/AAAA</param>
        /// <returns></returns>
        public static DateTime? PTtoDate(string DataPT)
        {
            try
            {

                if (DataPT == "" || DataPT == null)
                {
                    return null;
                }
                else
                {
                    DateTime ndata = new DateTime(int.Parse(DataPT.Substring(6, 4)), int.Parse(DataPT.Substring(3, 2)), int.Parse(DataPT.Substring(0, 2)));
                    return ndata;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de data. " + ex.Message);
                //return null;
            }
        }
        public static string DatetoString(DateTime? data, TipoData tipo)
        {
            try
            {
                if (data == null)
                {
                    return "";
                }
                else
                {
                    DateTime ndata = data ?? DateTime.Now;
                    switch (tipo)
                    {
                        case TipoData.Short:
                            return ndata.ToShortDateString();
                        case TipoData.Long:
                            return ndata.ToLongDateString();
                        case TipoData.Normal:
                            return ndata.ToString();
                        default:
                            return ndata.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de data. " + ex.Message);
            }
        }

        public enum TipoData
        {
            Short,
            Long,
            Normal
        }
    }
}
