﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace LibDatabase.DbContext
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class EntitiesMaraton : DbContext
{
    public EntitiesMaraton()
        : base("name=EntitiesMaraton")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Dystans> Dystans { get; set; }

    public virtual DbSet<dystans_info> dystans_info { get; set; }

    public virtual DbSet<grupa_kolarska> grupa_kolarska { get; set; }

    public virtual DbSet<kartoteka_2018> kartoteka_2018 { get; set; }

    public virtual DbSet<kartoteka_TMP> kartoteka_TMP { get; set; }

    public virtual DbSet<kartoteka2> kartoteka2 { get; set; }

    public virtual DbSet<Plec> Plec { get; set; }

    public virtual DbSet<Exception_Table> Exception_Table { get; set; }


    public virtual int pDodajGrupa(string grupa)
    {

        var grupaParameter = grupa != null ?
            new ObjectParameter("grupa", grupa) :
            new ObjectParameter("grupa", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pDodajGrupa", grupaParameter);
    }


    public virtual int pKartotekaZawodnikaDodaj(string imie, string nazwisko, string email, Nullable<System.DateTime> dataU, Nullable<int> plec_id, string fafon, string uwagi, Nullable<int> dys_id, Nullable<int> grupa_id, Nullable<bool> rejestrcja, Nullable<bool> rezerwa)
    {

        var imieParameter = imie != null ?
            new ObjectParameter("imie", imie) :
            new ObjectParameter("imie", typeof(string));


        var nazwiskoParameter = nazwisko != null ?
            new ObjectParameter("nazwisko", nazwisko) :
            new ObjectParameter("nazwisko", typeof(string));


        var emailParameter = email != null ?
            new ObjectParameter("email", email) :
            new ObjectParameter("email", typeof(string));


        var dataUParameter = dataU.HasValue ?
            new ObjectParameter("dataU", dataU) :
            new ObjectParameter("dataU", typeof(System.DateTime));


        var plec_idParameter = plec_id.HasValue ?
            new ObjectParameter("plec_id", plec_id) :
            new ObjectParameter("plec_id", typeof(int));


        var fafonParameter = fafon != null ?
            new ObjectParameter("fafon", fafon) :
            new ObjectParameter("fafon", typeof(string));


        var uwagiParameter = uwagi != null ?
            new ObjectParameter("uwagi", uwagi) :
            new ObjectParameter("uwagi", typeof(string));


        var dys_idParameter = dys_id.HasValue ?
            new ObjectParameter("dys_id", dys_id) :
            new ObjectParameter("dys_id", typeof(int));


        var grupa_idParameter = grupa_id.HasValue ?
            new ObjectParameter("grupa_id", grupa_id) :
            new ObjectParameter("grupa_id", typeof(int));


        var rejestrcjaParameter = rejestrcja.HasValue ?
            new ObjectParameter("rejestrcja", rejestrcja) :
            new ObjectParameter("rejestrcja", typeof(bool));


        var rezerwaParameter = rezerwa.HasValue ?
            new ObjectParameter("rezerwa", rezerwa) :
            new ObjectParameter("rezerwa", typeof(bool));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("pKartotekaZawodnikaDodaj", imieParameter, nazwiskoParameter, emailParameter, dataUParameter, plec_idParameter, fafonParameter, uwagiParameter, dys_idParameter, grupa_idParameter, rejestrcjaParameter, rezerwaParameter);
    }

}

}

