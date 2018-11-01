using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip2.Interfaces
{
    [ServiceContract]
    public interface IGenericService<T> where T : class
    {
        [OperationContract]
        T Kaydet(T entity);
        [OperationContract]
        List<T> Listele();
        [OperationContract]
        T Getir(int id);
        [OperationContract]
        int Guncelle(T entity);
        [OperationContract]
        bool Sil(int id);
        [OperationContract]
        T Sil(T entity);
        //Expressionları almadım .. >DAL > ISTOKDAL
    }
}
