using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Models;

namespace Echo_HemAPI.Helper
{
    public class SeedRealtorFirms
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SeedRealtorFirms()
        {
            
        }

        public SeedRealtorFirms(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        

        // Some swedish firms from https://xn--mklare-bua.se/m%C3%A4klarbyr%C3%A5er
        public void SeedFirms()
        {
            if (_applicationDbContext.RealtorFirms.Count() < 1)
            {
                return;
            }            
            else
            {
                _applicationDbContext.AddRange(
                new RealtorFirm
                {
                    Name = "Alvhem",
                    RealtorFirmPresentation = "Alvhem specialiserar sig på förmedling av fastigheter uppförda mellan 1850- och 1960-talet i Göteborg. Mäklarbyrån erbjuder ett handplockat utbud av fastigheter och fokuserar på att framhäva det unika och personliga med varje bostad de förmedlar.",
                    Logotype = null,
                    //new Picture(6, "https://fatcamp.io/xn--mklare-bua.se/images/companies/logo/alvhem-logotyp.png"),
                    Employees = null,
                    Estates = null
                },

                new RealtorFirm
                {
                    Name = "Croisette",
                    RealtorFirmPresentation = "Croisette förmedlar både privata bostäder och kommersiella fastigheter. Dessutom erbjuds rådgivning inom bland annat fastighetsförmedling och försäkringsförmedling, samt extratjänster som homestyling.",
                    Logotype = null,
                    //new Picture(2, "https://fatcamp.io/xn--mklare-bua.se/images/companies/logo/croisette-logo-square.png"),
                    Employees = null,
                    Estates = null
                },

                new RealtorFirm
                {
                    Name = "Historiska Hem",
                    RealtorFirmPresentation = "Historiska Hem förmedlar bostäder i Stockholmsområdet uppförda innan år 1970. Genom medvetet utvalda lägenheter, villor och radhus erbjuder Historiska Hem ett handplockat utbud av bostäder med historiskt värde för både köpare och säljare.",
                    Logotype = null,
                    // new Picture(3, "https://fatcamp.io/xn--mklare-bua.se/images/companies/logo/historiska-hem-logo-square.png"),
                    Employees = null,
                    Estates = null
                },

                new RealtorFirm
                {
                    Name = "Svenska Mäklarhuset",
                    RealtorFirmPresentation = "Svenska Mäklarhuset har sedan 1990 förmedlat bostadsrätter, villor och fritidshus, och har idag över 30 svenska och utländska kontor. De svenska kontoren är spridda över Storstockholm, Uppsala, Västerås, Göteborg, Skåne och Halland. De utländska kontoren hittar du i Spanien, Portugal, Cypern, Turkiet, Grekland, Kroatien och Thailand.",
                    Logotype = null,
                    // new Picture(4, "https://fatcamp.io/xn--mklare-bua.se/images/companies/logo/Svenska-maklarhuset-logo-square.png"),
                    Employees = null,
                    Estates = null
                });
            }
        }
    }
}