using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
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
    // Register this entity in your DbContext (usually in the BusinessObjects folder of your project) with the "public DbSet<Interrupcao> Interrupcaos { get; set; }" syntax.
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    // You do not need to implement the INotifyPropertyChanged interface - EF Core implements it automatically.
    // (see https://learn.microsoft.com/en-us/ef/core/change-tracking/change-detection#change-tracking-proxies for details).
    //[NavigationItem("Cadastro")]
    [XafDisplayName("Interrupção")]
    public class Interrupcao : BaseObject
    {
        public Interrupcao()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();

        }

        public override void OnCreated()
        {
            base.OnCreated();
            DateTime minDate = new DateTime(1900, 01, 01);

            this.DataLancamento = DateTime.Now;

            var parametroAtual = this.ObjectSpace.FirstOrDefault<Parametro>(p => true);
            if (parametroAtual != null)
            {
                this.VersaoId = parametroAtual.VersaoId;
                this.Versao = parametroAtual.VersaoAtual;
            }
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

        [XafDisplayName("Data"), ToolTip("Data da interrupção")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Column(TypeName = "smalldatetime")]
        [ModelDefault("DisplayFormat", "{0: dd/MM/yyyy HH:mm}")]
        [ModelDefault("EditMask", "dd/MM/yyyy HH:mm")]
        public virtual DateTime DataLancamento { get; set; }

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public virtual Guid VersaoId { get; set; }

        [XafDisplayName("Versão")]
        //[Association("FormaPagamento_Pessoa", "", "", IsForeignKey = true)]
        [ForeignKey("VersaoId")]
        public virtual Versao Versao { get; set; }

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public virtual Guid? ColaboradorId { get; set; }

        [XafDisplayName("Colaborador")]
        //[Association("FormaPagamento_Pessoa", "", "", IsForeignKey = true)]
        [ForeignKey("ColaboradorId")]
        public virtual Colaborador? Colaborador { get; set; }

        // Alternatively, specify more UI options:
        [XafDisplayName("Tempo consumido"), ToolTip("Tempo em minutos consumido pela interrupção")]
        [Column(TypeName = "int")]
        public virtual int TempoConsumido { get; set; }

        [XafDisplayName("Descrição"), ToolTip("Descrição da interrupção")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Column(TypeName = "varchar(5000)")]
        public virtual string Descricao { get; set; }
    }
}