using KoleServis.MVVM.Models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoleServis.Services
{
    public class FindService
    {
        public FindService() { }
        public Kupac FindCustomer(int? idCustomer)
        {
            using (var context = new HcitableContext())
            {
                var customers = context.Kupacs.ToList();

                foreach (var customer in customers)
                {
                    if (customer.IdKupac == idCustomer)
                    {
                        return customer;
                    }
                }
            }
            return null;
        }
        public ObservableCollection<Kupac> FindAllCustomer()
        {
            ObservableCollection<Kupac> kupci=new ObservableCollection<Kupac>();
            using (var context = new HcitableContext())
            {
                var customers = context.Kupacs.ToList();

                foreach (var customer in customers)
                {
                    kupci.Add(customer);
                }
            }
            return kupci;
        }
        public ObservableCollection<IResource> FindItemOnBill(int? idRacun)
        {
            ObservableCollection<IResource> itemCollection = new ObservableCollection<IResource>();
            using (var context = new HcitableContext())
            {
                var items = context.StavkaDios.ToList();

                foreach (var item in items)
                {
                    if (item.RacunIdRacun == idRacun)
                    {
                        itemCollection.Add(item);
                    }
                }
            }
            return itemCollection;
        }
        public Kategorija FindCategory(int? idCategory)
        {
            using(var context= new HcitableContext())
            {
                var categories = context.Kategorijas.ToList();
                foreach(var category in categories)
                {
                    if(category.IdKategorija == idCategory)
                    {
                        return category;
                    }
                }
            }
            return null;
        }
        public int FindIdCategory(string? titleCategory)
        {
            using (var context = new HcitableContext())
            {
                var categories = context.Kategorijas.ToList();
                foreach (var category in categories)
                {
                    if (category.Naziv == titleCategory)
                    {
                        return category.IdKategorija;
                    }
                }
            }
            return 0;
        }
        public ObservableCollection<IResource> FindServiceOnBill(int? idRacun)
        {
            ObservableCollection<IResource> serviceCollection = new ObservableCollection<IResource>();
            using (var context = new HcitableContext())
            {
                var items = context.StavkaUslugas.ToList();

                foreach (var item in items)
                {
                    if (item.RacunIdRacun == idRacun)
                    {
                        serviceCollection.Add(item);
                    }
                }
            }
            return serviceCollection;
        }

        public Osoba FindPerson(string username)
        {
            using (var context = new HcitableContext())
            {
                var persons = context.Osobas.ToList();

                foreach (var person in persons)
                {
                    if (person.KorisnickoIme.Equals(username))
                    {
                        return person;
                    }
                }
            }
            return null;
        }
        public Dio FindItem(int? idDio)
        {
            using (var context = new HcitableContext())
            {
                var items = context.Dios.ToList();

                foreach (var item in items)
                {
                    if (item.IdDio == idDio)
                    {
                        return item;
                    }
                    {
                        
                    }
                }
            }
            return null;
        }
        public Usluga FindServices(int? idUsluga)
        {
            using (var context = new HcitableContext())
            {
                var items = context.Uslugas.ToList();

                foreach (var item in items)
                {
                    if (item.IdUsluga== idUsluga)
                    {
                        return item;
                    }
                    {

                    }
                }
            }
            return null;
        }

        public Tema findTheme(int? idTema)
        {
            using(var context = new HcitableContext())
            {
                var themes=context.Temas.ToList();
                foreach (var theme in themes)
                {
                    if (theme.IdTema == idTema) { return theme; }
                }
            }
            return null;
        }

        public ObservableCollection<string> GetColor() {
            ObservableCollection<string> strings = new ObservableCollection<string>();
            using(var context = new HcitableContext())
            {
                var themes = context.Temas.ToList();
                foreach(var theme in themes)
                {
                    if (!strings.Contains(theme.Boja))
                        strings.Add(theme.Boja);
                }
            }
            return strings;
        }
        public ObservableCollection<string> GetFonts()
        {
            ObservableCollection<string> strings = new ObservableCollection<string>();
            using (var context = new HcitableContext())
            {
                var themes = context.Temas.ToList();
                foreach (var theme in themes)
                {
                    if(!strings.Contains(theme.Font))
                        strings.Add(theme.Font);
                }
            }
            return strings;
        }
        public ObservableCollection<string> GetLanguages()
        {
            ObservableCollection<string> strings = new ObservableCollection<string>();
            using (var context = new HcitableContext())
            {
                var languages = context.Jeziks.ToList();
                foreach (var language in languages)
                {
                    if(!strings.Contains(language.Naziv))
                        strings.Add(language.Naziv);
                }
            }
            return strings;
        }

        public int CheckAndAddTheme(Tema theme)
        {
            using (var context= new HcitableContext())
            {
                var existingEntity=context.Temas.FirstOrDefault(e=>e.Boja.Equals(theme.Boja) && e.Font.Equals(theme.Font) && e.Bold==theme.Bold && e.Italic==theme.Italic);
                if (existingEntity != null)
                {
                    return existingEntity.IdTema;
                }
                var newTheme = theme;
                context.Temas.Add(newTheme);
                context.SaveChanges();
                return newTheme.IdTema;

            }
        }

    }
}
