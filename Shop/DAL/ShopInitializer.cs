using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shop.DAL
{///DropCreateDatabaseIfModelChanges<ShopContext>
 ///DropCreateDatabaseAlways<ShopContext>
    public class ShopInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));

            roleManager.Create(new IdentityRole("Admin"));
            var user = new ApplicationUser { UserName = "mkopowka@wp.pl" };
            string passwor = "Mati123";

            userManager.Create(user, passwor);
            userManager.AddToRole(user.Id, "Admin");

            var users = new List<User>
            {
                new User { FirstName="Mateusz",LastName="Kopowka",Email="mkopowka@wp.pl" }
            };
            users.ForEach(p => context.Users.Add(p));

            var category = new List<Category>
            {
                new Category {Name ="Smartfony", Description ="Same najlepsze modele, w najlepszych cenach."},
                new Category {Name ="Ładowarki", Description ="Ładowarki dla każdego rodzaju telefonu."},
                new Category {Name ="Akcesoria", Description ="Znajdziecie tutaj akcesoria do telefonów komórkowych." }
            };
            category.ForEach(p => context.Categories.Add(p));

            var warehouse = new List<Warehouse>
            {
                new Warehouse {City ="Siedce", Voivodeship =Voivodeship.Mazowieckie,PostalCode="08-110",Street="Klonowa",BuildingNumber=7 },
                new Warehouse {City ="Białystok", Voivodeship= Voivodeship.Podlaskie,PostalCode="08-310",Street="Pozioma",BuildingNumber=3 }
            };
            warehouse.ForEach(p => context.Warehouses.Add(p));

            var prod = new List<Producer>
            {
                new Producer {Name ="Apple", Description ="Amerykańska korporacja zajmująca się projektowaniem i produkcją elektroniki użytkowej, oprogramowania i komputerów osobistych z siedzibą w Cupertino w Kalifornii. Założona 1 kwietnia 1976 r. przez Steve’a Wozniaka – projektanta, Steve’a Jobsa i przedsiębiorcę Ronalda Wayne’a, aby projektować i sprzedawać kompletne, zmontowane zestawy komputerów osobistych. Od stycznia 1977 r. działała formalnie jako spółka Apple Computer Inc., a od stycznia 2007 r. nazwę zmieniono na Apple Inc. w celu odzwierciedlenia zmian w strategii firmy w stronę projektowania, produkcji i sprzedaży szeroko rozumianej elektroniki użytkowej i usług. Produkty spółki to m.in.: komputery Mac, iPod, iPhone, iPad, Apple Watch. Oprogramowanie Apple obejmuje system operacyjny macOS, przeglądarkę multimediów iTunes, pakiet oprogramowania multimedialnego i kreatywności iLife, pakiet oprogramowania biurowego iWork, profesjonalny pakiet fotografii Aperture, pakiet profesjonalnych rozwiązań wideo Final Cut Studio oraz zestaw narzędzi audio Logic Studio. Od stycznia 2010 roku firma działa poprzez 284 własnych sklepów detalicznych w dziesięciu krajach oraz za pośrednictwem sklepu internetowego sprzedającego zarówno sprzęt, jak i oprogramowanie." },
                new Producer {Name ="Nokia", Description="Fińskie przedsiębiorstwo zajmujące się tworzeniem map i innymi technologiami telekomunikacyjnymi. Znane z produkcji telefonów komórkowych. W kwietniu 2014 dział urządzeń i usług został przejęty przez Microsoft, a w maju 2016 dział telefonów podstawowych (ang. featurephone) został odkupiony przez FIH Mobile (Foxconn) oraz HMD Global, który odkupił również 10-letnią licencję na prawa do korzystania z marki Nokia." },
                new Producer {Name ="Huaweii", Description="Chińskie przedsiębiorstwo, założone w 1987 roku, specjalizujące się w produkcji urządzeń i rozwiązań telekomunikacyjnych oraz informatycznych. Znak 华 oznacza zarówno „chiński” jak i „znakomity”, „wspaniały”. Założycielem oraz prezesem przedsiębiorstwa jest Ren Zhengfei. Siedzibą firmy jest Shenzhen, w prowincji Guangdong, w Chińskiej Republice Ludowej." },
                new Producer {Name ="Nillkin", Description= "Firma produkująca najlepszej jakości pokrowcami do telefonów " }
            };
            prod.ForEach(p => context.Producers.Add(p));

            var item = new List<Product>
            {
                new Product {Name = "iPhone SE 16GB Złoty", Price =1300, Description ="Przekątna ekranu[cal]: 4, System operacyjny iOS, Pamięć RAM 2GB, Liczba rdzeni procesora: 2", Category= category[0] ,Producer=prod[0]},
                new Product {Name = "iPhone 8 64GB Czarny", Price =3100, Description ="Przekątna ekranu[cal]: 4.7, System operacyjny iOS, Pamięć RAM 2GB, Liczba rdzeni procesora: 6", Category=category[0],Producer=prod[0] },
                new Product {Name = "Mate 10 Lite 64GB Czarny", Price =1200, Description ="Przekątna ekranu[cal]: 5.9, System operacyjny Android, Pamięć RAM 4GB, Liczba rdzeni procesora: 8",  Category=  category[0],Producer=prod[2] },
                new Product {Name = "Nokia 8 64GB Miedziany", Price =2200, Description ="Przekątna ekranu[cal]: 5.3, System operacyjny Android, Pamięć RAM 64GB, Liczba rdzeni procesora: 8", Category=  category[0] ,Producer=prod[1]},
                new Product {Name = "Super Shield Czarne", Price =40, Description ="Pokrowiec do telefonu Huaweii Mate 10 Lite", Category= category[2] ,Producer=prod[3]}
            };
            item.ForEach(p => context.Products.Add(p));

            context.SaveChanges();
        }
    }
}