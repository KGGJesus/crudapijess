using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaTI.Models;

namespace PracticaTI.Services
{
    public class BebidaService
    {
                static List<Bebida> Bebidas {get;}

        static int nextId = 4;

        static BebidaService ()
        {
            Bebidas = new List <Bebida> {
                new Bebida {ID = 1, Name = "Agua de Jamaica", sodio = false},
                new Bebida {ID = 2, Name = "Agua de Horchata", sodio = false},
                new Bebida {ID = 2, Name = "Coca-cola ", sodio = false},
                new Bebida {ID = 2, Name = "Fanta", sodio = false},
            };
        }
    
    public static List<Bebida> GetAll()=> Bebidas;

    public static Bebida Get(int ID) => Bebidas.FirstOrDefault(p => p.ID == ID);


    public static void Add(Bebida bebida)
    {
        bebida.ID = nextId++;
        Bebidas.Add(bebida);

    }
    public static void Delete(int iD )
    {
        var bebida = Get(iD);
        if(bebida is null)
            return;

            Bebidas.Remove(bebida);
           
    }

    public static void Update(Bebida bebida)
    {
        var Index = Bebidas.FindIndex(p => p.ID == bebida.ID);
        if (Index == -1)
        return;

        Bebidas[Index] = bebida;
    }




    
    }
}