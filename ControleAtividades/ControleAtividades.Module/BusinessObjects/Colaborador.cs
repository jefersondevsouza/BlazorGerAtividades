using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ControleAtividades.Module.BusinessObjects
{
    // Register this entity in your DbContext (usually in the BusinessObjects folder of your project) with the "public DbSet<Colaborador> Colaboradors { get; set; }" syntax.
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    // You do not need to implement the INotifyPropertyChanged interface - EF Core implements it automatically.
    // (see https://learn.microsoft.com/en-us/ef/core/change-tracking/change-detection#change-tracking-proxies for details).
    //[NavigationItem("Cadastro")]
    [XafDisplayName("Colaborador")]
    public class Colaborador : BaseObject
    {
        public Colaborador()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
            this.Atividades = new ObservableCollection<Atividade>();
            this.Interrupcoes = new ObservableCollection<Interrupcao>();
            //this._InterrupcoesVersao = new ObservableCollection<Interrupcao>();
            //this._AtividadesVersao = new ObservableCollection<Atividade>();
        }

        // You can use the regular Code First syntax.
        // Property change notifications will be created automatically.
        // (see https://learn.microsoft.com/en-us/ef/core/change-tracking/change-detection#change-tracking-proxies for details)
        //public virtual string Name { get; set; }

        // Alternatively, specify more UI options:
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), VisibleInListView(false)]
        //[RuleRequiredField(DefaultContexts.Save)]
        //public virtual string Name { get; set; }

        // Collection property:
        //public virtual IList<AssociatedEntityObject> AssociatedEntities { get; set; }

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}

        // Alternatively, specify more UI options:
        [XafDisplayName("Nome"), ToolTip("Nome")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Column(TypeName = "varchar(100)")]
        public virtual string Nome { get; set; }

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public virtual Guid CargoId { get; set; }

        [XafDisplayName("Cargo")]
        [RuleRequiredField(DefaultContexts.Save)]
        //[Association("FormaPagamento_Pessoa", "", "", IsForeignKey = true)]
        [ForeignKey("CargoId")]
        public virtual Cargo Cargo { get; set; }

        // Alternatively, specify more UI options:
        [XafDisplayName("Qtde. Horas Dia"), ToolTip("Quantidade de horas diárias disponível")]
        [Column(TypeName = "int")]
        [VisibleInLookupListView(false)]
        public virtual int NumeroHorasDia { get; set; }

        [XafDisplayName("Hora inicial"), ToolTip("Horário de inicio")]
        [RuleRequiredField(DefaultContexts.Save)]
        [ModelDefault("EditMask", "00:00")]
        [Column(TypeName = "varchar(5)")]
        [VisibleInLookupListView(false)]
        public virtual string HoraInicial { get; set; }

        [XafDisplayName("Hora final"), ToolTip("Horário de saída")]
        [RuleRequiredField(DefaultContexts.Save)]
        [ModelDefault("EditMask", "00:00")]
        [Column(TypeName = "varchar(5)")]
        [VisibleInLookupListView(false)]
        public virtual string HoraFinal { get; set; }

        [XafDisplayName("Inicio intervalo"), ToolTip("Horário de inicio do intervalo")]
        [RuleRequiredField(DefaultContexts.Save)]
        [ModelDefault("EditMask", "00:00")]
        [Column(TypeName = "varchar(5)")]
        [VisibleInLookupListView(false)]
        public virtual string HoraInicialIntervalo { get; set; }

        [XafDisplayName("Fim intervalo"), ToolTip("Horário fim do intervalo")]
        [RuleRequiredField(DefaultContexts.Save)]
        [ModelDefault("EditMask", "00:00")]
        [Column(TypeName = "varchar(5)")]
        [VisibleInLookupListView(false)]
        public virtual string HoraFinalIntervalo { get; set; }

        [XafDisplayName("Atividades"), ToolTip("Atividades realizadas na versão")]
        public virtual IList<Atividade> Atividades { get; set; }

        [XafDisplayName("Interrupções"), ToolTip("Interrupções")]
        public virtual IList<Interrupcao> Interrupcoes { get; set; }

        //[VisibleInDetailView(false)]
        //[VisibleInListView(false)]
        //[VisibleInLookupListView(false)]
        //[NonPersistent]
        //public IList<Atividade> _AtividadesVersao { get; set; }

        //[VisibleInDetailView(false)]
        //[VisibleInListView(false)]
        //[VisibleInLookupListView(false)]
        //[NonPersistent]
        //public IList<Interrupcao> _InterrupcoesVersao { get; set; }

        //[XafDisplayName("Atividades na versão"), ToolTip("Atividades na versão atual")]
        ////[CriteriaOptions(]
        //public virtual IList<Atividade> AtividadesVersao
        //{
        //    get
        //    {
        //        var parametroAtual = this.ObjectSpace.FirstOrDefault<Parametro>(p => true);
        //        if (parametroAtual != null)
        //        {
        //            _AtividadesVersao = ObjectSpace.GetObjectsQuery<Atividade>().Where(t => t.VersaoId == parametroAtual.VersaoId).ToList();
        //        }
        //        else
        //        {
        //            _AtividadesVersao = ObjectSpace.GetObjectsQuery<Atividade>().Where(t => true).ToList();
        //        }

        //        return _AtividadesVersao;
        //    }
        //    set { _AtividadesVersao = value; }
        //}

        //[XafDisplayName("Interrupções na versão"), ToolTip("Interrupções recebidas na versão atual")]
        ////[CriteriaOptions(]
        //public virtual IList<Interrupcao> InterrupcoesVersao
        //{
        //    get
        //    {
        //        var parametroAtual = this.ObjectSpace.FirstOrDefault<Parametro>(p => true);
        //        if (parametroAtual != null)
        //        {
        //            _InterrupcoesVersao = ObjectSpace.GetObjectsQuery<Interrupcao>().Where(t => t.VersaoId == parametroAtual.VersaoId).ToList();
        //        }
        //        else
        //        {
        //            _InterrupcoesVersao = ObjectSpace.GetObjectsQuery<Interrupcao>().Where(t => true).ToList();
        //        }

        //        return _InterrupcoesVersao;
        //    }
        //    set { _InterrupcoesVersao = value; }
        //}

        [NonPersistent]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string FullName { get { return Nome; } }
    }
}