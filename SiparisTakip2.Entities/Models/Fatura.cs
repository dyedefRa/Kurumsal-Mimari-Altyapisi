namespace SiparisTakip2.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fatura")]
    public partial class Fatura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fatura()
        {
            FaturaDetay = new HashSet<FaturaDetay>();
        }

        public int FaturaID { get; set; }

        public int? CariID { get; set; }

        [StringLength(20)]
        public string CariKodu { get; set; }

        [StringLength(200)]
        public string CariAdi { get; set; }

        [StringLength(200)]
        public string CariAdresi { get; set; }

        [StringLength(20)]
        public string CariIlce { get; set; }

        [StringLength(20)]
        public string CariIl { get; set; }

        [StringLength(200)]
        public string CariVergiDairesi { get; set; }

        [StringLength(25)]
        public string CariVergiNo { get; set; }

        public bool? FaturaIslemTuru { get; set; }

        [Column(TypeName = "date")]
        public DateTime? IrsaliyeTarihi { get; set; }

        [StringLength(100)]
        public string IrsaliyeNo { get; set; }

        [StringLength(8)]
        public string IrsaliyeSaati { get; set; }

        public bool? FaturaDurum { get; set; }

        [StringLength(100)]
        public string FaturaNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FaturaTarihi { get; set; }

        [StringLength(8)]
        public string FaturaSaati { get; set; }

        public int? VedeGun { get; set; }

        [Column(TypeName = "date")]
        public DateTime? VadeTarihi { get; set; }

        public byte? FaturaTipi { get; set; }

        public int? SatisElemanID { get; set; }

        public int? DepoID { get; set; }

        public bool? KdvDahil { get; set; }

        public decimal? AraToplam { get; set; }

        public decimal? ToplamIndirim { get; set; }

        public decimal? ToplamTutar { get; set; }

        public decimal? ToplamKdv { get; set; }

        public decimal? GenelToplam { get; set; }

        public bool? Iptal { get; set; }

        public DateTime KayitZamani { get; set; }

        [StringLength(30)]
        public string MACCAdress { get; set; }

        public int KullaniciID { get; set; }

        public int? SatisID { get; set; }

        public byte? SatisTarifesi { get; set; }

        public byte StokIslemTuruID { get; set; }

        public bool HizliStokGiris { get; set; }

        [Column(TypeName = "date")]
        public DateTime Tarih { get; set; }

        public bool HizliSatis { get; set; }

        public byte? OdemeSekliID { get; set; }

        public decimal? Odenen { get; set; }

        public decimal? Kalan { get; set; }

        public int? BankaHesapID { get; set; }

        public bool? FaturaKapat { get; set; }

        public decimal? AraToplam0 { get; set; }

        public decimal? AraToplam1 { get; set; }

        public decimal? Kdv1 { get; set; }

        public decimal? AraToplam8 { get; set; }

        public decimal? Kdv8 { get; set; }

        public decimal? AraToplam18 { get; set; }

        public decimal? Kdv18 { get; set; }

        public decimal? AsilToplam { get; set; }

        public bool? Iade { get; set; }

        [StringLength(5)]
        public string IrsaliyeSeri { get; set; }

        [StringLength(5)]
        public string FaturaSeri { get; set; }

        public int IsyeriID { get; set; }

        [StringLength(1500)]
        public string Aciklama { get; set; }

        public int? StokSayimID { get; set; }

        public virtual Cari Cari { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual Satis Satis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaturaDetay> FaturaDetay { get; set; }
    }
}
