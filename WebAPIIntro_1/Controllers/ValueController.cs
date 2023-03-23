using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIIntro_1.Controllers
{
    #region Notlar

    //MVC projelerinde bir Action'in basına bir HTTP attribute'u koymadığınız takdirde bu Action'in default Request'i Get olarak algılanır...

    //API projelerinde ise bu yöntemlerin özellikle yazılması gerekir...Yoksa Action tanınmaz...Tek istisnası (bu yöntemi yapmadığınız halde Action'in Request ile ulasılabilmesinin tek istinası) bu yöntemin isminin (Get,Post vs) Action isminin basına yazılmasıdır...

    //Eger HTTP yöntemini bir Attribute olarak tanımlamak istemezseniz o zaman yöntem adlarınız Action isminin basına yazılıyorsa buna Conventional Basing Route yöntemi denir... Attribute bazlı tanımlıyorsanız Attribute Basing Route yöntemi denir...


    //Dikkat ederseniz API'da aynı zamanda URL template'inin varsayılan hali de degişiktir... Sizden MVC gibi bir Action ismi istemez...


    /*
     
     Get: Bir sayfanın ilk kez istenmesidir(siz url'den aynı adresi tekrar enter ile isteseniz bile bu yeni bir istektir)


    Post: Size gelmiş olan bir sayfanın tekrar server'a geri gönderilmesidir(API'da özellikle sadece ekleme işlemleri icin kullanılır...Teknik olarak Post yönteminde güncelleme yapabiliyor olsanız da API'da güncelleme icin Post saglıklı degildir)

    Put : API'da güncelleme işlemleri icin tercih edilir...


    Delete: API'da silme işlemleri icin tercih edilir...
     
     
     
     
     
     */




    #endregion



    public class ValueController : ApiController
    {

        static List<string> _sehirler = new List<string>
        {
            "İstanbul","Ankara","İzmir","Yalova","Eskişehir","Mersin"
        };



        [HttpGet]
        public List<string> ListCities()
        {
            return _sehirler;
        }

        
        public string GetCity(int index)
        {
            return _sehirler[index];
        }

        [HttpPost]
        public List<string> AddCity(string city)
        {
            _sehirler.Add(city);
            return _sehirler;
        }

        [HttpPut]
        public List<string> UpdateCity(int index,string newValue)
        {
            _sehirler[index] = newValue;
            return _sehirler;
        }

        [HttpDelete]
        public List<string> DeleteCity(string item) 
        {
            _sehirler.Remove(item);
            
            return _sehirler;   
        
        }



    }
}
