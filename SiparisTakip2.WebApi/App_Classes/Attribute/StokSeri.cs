using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SiparisTakip2.WebApi.App_Classes.Attribute
{
    public class StokSeri
    {
        public int StokID { get; set; }

        [Required]
        [StringLength(30)]
        public string BarkodNo { get; set; }

        [StringLength(30)]
        public string StokKodu { get; set; }

        public int? StokGrubuID { get; set; }

        [StringLength(200)]
        public string StokAdi { get; set; }

        public int? StokBirimID { get; set; }

        public decimal? AlisFiyati { get; set; }

        public byte? AlisKdvDurumID { get; set; }

        public decimal? KdvOrani { get; set; }

        public decimal? SatisFiyati { get; set; }

        public decimal? Kdv { get; set; }

        public decimal? ToplamFiyati { get; set; }

        public byte? SatisKdvDurumID { get; set; }

        public int? MevcutStokAdeti { get; set; }

        public int? KritikStokAdeti { get; set; }

        public bool? Aktif { get; set; }

        public int? KullaniciID { get; set; }

        public DateTime? KayitZamani { get; set; }

        [StringLength(30)]
        public string MACCAdress { get; set; }

        public string Notlar { get; set; }

        [StringLength(100)]
        public string ResimUrl { get; set; }

        public bool? HizliMenuAktif { get; set; }

        public int? HizliMenuSira { get; set; }

        public decimal? SatisFiyati2 { get; set; }

        public byte? SatisKdvDurumID2 { get; set; }

        public decimal? SatisFiyati3 { get; set; }

        public byte? SatisKdvDurumID3 { get; set; }

        [StringLength(30)]
        public string OzelKodu1 { get; set; }

        [StringLength(30)]
        public string OzelKodu2 { get; set; }

        [Column(TypeName = "image")]
        public byte[] Resim { get; set; }

        public int? MarkaID { get; set; }

        public int? UrunMalzemeID { get; set; }

        public int? UrunCinsiyetID { get; set; }

        public int? IsyeriID { get; set; }

        public int? AltStokGrubID { get; set; }

        public int? AltStokGrubID2 { get; set; }

        public int? AltStokGrubID3 { get; set; }

        public int? RenkID { get; set; }

        public int? NumaraID { get; set; }

        public int? UzunlukID { get; set; }

        public decimal? SatisFiyati4 { get; set; }

        public byte? SatisKdvDurumID4 { get; set; }

        public decimal? SatisFiyati5 { get; set; }

        public byte? SatisKdvDurumID5 { get; set; }

        [StringLength(200)]
        public string StokAdi2 { get; set; }

        [StringLength(255)]
        public string StokKisaAciklama { get; set; }

        [StringLength(255)]
        public string StokAnahtarKelime { get; set; }

        public int ParaBirimiID { get; set; }
    }
}