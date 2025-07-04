using LPS_BLL.Models.ReportModels;
using LPS_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL
{
    public class Forecast
    {
        public void GetForecastNaive(List<LaporanForecastModel> arr)
        {
            double? last = 0;
            for (Int32 i = 0; i < (arr.Count); i++)
            {
                if (arr[i].Realisasi != null)
                { 
                    if (i == 0)
                    {
                        //first row, value gets itself
                        arr[i].Forecast = arr[i].Realisasi;
                    }
                    else
                    {
                        //Put the prior row's value into the current row's forecasted value
                        arr[i].Forecast = arr[i - 1].Realisasi;
                    }
                    last = arr[i].Realisasi;
                    arr[i].Error = arr[i].Forecast - arr[i].Realisasi;
                }
                else
                {
                    arr[i].Forecast = last;
                }
                arr[i].Forecast = Math.Round(arr[i].Forecast.Value, MidpointRounding.AwayFromZero);
            }
        }

        public void GetForecastSMA(List<LaporanForecastModel> arr,int periode = 3)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                if (i < periode)
                {
                    arr[i].Forecast = arr[i].Realisasi;
                    arr[i].Error = arr[i].Forecast - arr[i].Realisasi;
                }
                else
                {
                    double? avg = 0;
                    for (int k = i - periode; k < i; k++)
                    {
                        if (arr[k].Realisasi != null)
                        {
                            avg += arr[k].Realisasi;
                            arr[i].Error = arr[i].Forecast - arr[i].Realisasi;
                        }
                        else
                        {
                            avg += arr[k].Forecast;
                        }
                    }
                    avg /= periode;
                    arr[i].Forecast =  avg;
                }
                arr[i].Forecast = Math.Round(arr[i].Forecast.Value, MidpointRounding.AwayFromZero);
            }
        }

        public void GetForecastWMA(List<LaporanForecastModel> arr)
        {
            double[] periodeWeight = { 0.05, 0.15, 0.8 };
            var periode = periodeWeight.Length;
            var test = (double)0;
            test = periodeWeight.Sum();
            if (test != 1)
            {
                return;
            }

            for (int i = 0; i < arr.Count; i++)
            {
                if (i == 0)
                {
                    arr[i].Forecast = arr[i].Realisasi;
                    arr[i].Error = arr[i].Forecast - arr[i].Realisasi;
                }
                else
                {
                    double? avg = 0;
                    if (i < periode)
                    {
                        for (int k = 0; k < i; k++)
                        {
                            avg += arr[k].Realisasi * (1 / (double)i);
                        }
                    }
                    else
                    {
                        var j = 0;
                        for (int k = i - periode; k < i; k++)
                        {
                            if (arr[k].Realisasi != null)
                            {
                                avg += arr[k].Realisasi * periodeWeight[j];
                            }
                            else
                            {
                                avg += arr[k].Forecast * periodeWeight[j];
                            }
                            j++;
                        }
                    }
                    arr[i].Forecast = avg;
                    if (arr[i].Realisasi != null)
                    {
                        arr[i].Error = arr[i].Forecast - arr[i].Realisasi;
                    }
                }
                arr[i].Forecast = Math.Round(arr[i].Forecast.Value, MidpointRounding.AwayFromZero);
            }
        }

        public void GetForecastES(List<LaporanForecastModel> arr, double alpha = 0.8)
        {
            double? priorForecast;
            double? priorValue;
            for (int i = 0; i < arr.Count; i++)
            {
                if (i == 0)
                {
                    arr[i].Forecast = arr[i].Realisasi;
                    arr[i].Error = arr[i].Forecast - arr[i].Realisasi;
                }
                else
                {
                    priorForecast = arr[i - 1].Forecast;
                    if (arr[i].Realisasi != null)
                    {
                        priorValue = arr[i-1].Realisasi;
                    }
                    else
                    {
                        priorValue = arr[i-1].Forecast;
                    }
                    arr[i].Forecast = priorForecast + (alpha * (priorValue - priorForecast));
                    if (arr[i].Realisasi != null)
                    {
                        arr[i].Error = arr[i].Forecast - arr[i].Realisasi;
                    }
                }
                arr[i].Forecast = Math.Round(arr[i].Forecast.Value, MidpointRounding.AwayFromZero);
            }
        }

        public void GetForecastARS(List<LaporanForecastModel> arr, double MinGamma = 0.2, double MaxGamma = 0.8)
        {
            double? priorForecast;
            double? priorValue;
            double Gamma = 0;
            List<LaporanForecastModel> dt = new List<LaporanForecastModel>();
            for (int i = 0; i < arr.Count; i++)
            {

                if (i == 0)
                {
                    arr[i].Forecast = arr[i].Realisasi;
                    arr[i].Error = arr[i].Forecast - arr[i].Realisasi;
                }
                else
                {
                    priorForecast = arr[i - 1].Forecast;
                    if (arr[i].Realisasi != null)
                    {
                        priorValue = arr[i - 1].Realisasi;
                        Gamma = Math.Abs(TrackingSignal(arr, false, 3, i));
                        if (Gamma < MinGamma)
                            Gamma = MinGamma;
                        if (Gamma > MaxGamma)
                            Gamma = MaxGamma;
                    }
                    else
                    {
                        priorValue = arr[i - 1].Forecast;
                    }

                    arr[i].Forecast = priorForecast + (Gamma * (priorValue - priorForecast));
                    if (arr[i].Realisasi != null)
                    {
                        arr[i].Error = arr[i].Forecast - arr[i].Realisasi;
                    }
                }
                arr[i].Forecast = Math.Round(arr[i].Forecast.Value, MidpointRounding.AwayFromZero);
            }
        }

        //Tracking signal = MeanSignedError / MeanAbsoluteError
        public static double TrackingSignal(List<LaporanForecastModel> dt, bool Holdout, int IgnoreInitial, int i)
        {
            double MAE = MeanAbsoluteError(dt, Holdout, IgnoreInitial, i);
            if (MAE == 0)
                return 0;

            return MeanSignedError(dt, Holdout, IgnoreInitial,i) / MAE;
        }

        //MeanSignedError = Sum(E(t)) / n
        public static double MeanSignedError(List<LaporanForecastModel> dt, bool Holdout, int IgnoreInitial,int i)
        {
            double avg = 0;
            if (i - IgnoreInitial <= 1)
            {
                return avg;
            }

            for (int j = IgnoreInitial + 1; j < i; j++)
            {
                avg += dt[j].Error.Value;
            }

            avg /= (i - IgnoreInitial + 1);

            return avg;
        }

        //MeanAbsoluteError = Sum(|E(t)|) / n
        public static double MeanAbsoluteError(List<LaporanForecastModel> dt, bool Holdout, int IgnoreInitial, int i)
        {
            double avg = 0;
            if (i - IgnoreInitial <= 1)
            {
                return avg;
            }

            for (int j = IgnoreInitial + 1; j < i; j++)
            {
                avg += Math.Abs(dt[j].Error.Value);
            }

            avg /= (i - IgnoreInitial + 1);

            return avg;
        }

        public void GetForecastLinear(List<LaporanForecastModel> arr)
        {
            int j = 1;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i].Realisasi != null && arr[i + 1].Realisasi == null)
                {
                    arr[i].Forecast = arr[i].Realisasi;
                }
                if (arr[i].Realisasi == null)
                {
                    arr[i].Forecast = (((arr[i - j].Realisasi - arr[i - j - 2].Realisasi) / (double)2) * j) + arr[i - j].Realisasi;
                    arr[i].Forecast = Math.Round(arr[i].Forecast.Value, MidpointRounding.AwayFromZero);
                    j++;
                }
            }
        }

        public void ForecastProccess(List<LaporanForecastModel> arr, int forecastMethod)
        {

            if (forecastMethod == (int)FORECAST_METHOD.Naive)
            {
                GetForecastNaive(arr);
            }
            else if (forecastMethod == (int)FORECAST_METHOD.SMA)
            {
                GetForecastSMA(arr);
            }
            else if (forecastMethod == (int)FORECAST_METHOD.WMA)
            {
                GetForecastWMA(arr);
            }
            else if (forecastMethod == (int)FORECAST_METHOD.ES)
            {
                GetForecastES(arr);
            }
            else if (forecastMethod == (int)FORECAST_METHOD.ARS)
            {
                GetForecastARS(arr);
            }
            else if (forecastMethod == (int)FORECAST_METHOD.Linear)
            {
                GetForecastLinear(arr);
            }
        }

        public List<LaporanForecastModel> GetListEksekusiForecast(int projectHeaderId)
        {
            var oParameters = new
            {
                IDProjectHeader = projectHeaderId
            };
            try
            {
                var data = DbTransaction.DbToList<LaporanForecastModel>("Usp_Get_ProjectEksekusiReportForecast", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProjectForecastModel> GetListEksekusi(string personnumber)
        {

            var oParameters = new
            {
                personnumber = personnumber
            };
            try
            {
                var data = DbTransaction.DbToList<ProjectForecastModel>("Usp_Get_ProjectEksekusiListForecast", oParameters, true);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
