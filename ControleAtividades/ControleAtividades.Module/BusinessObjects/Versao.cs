using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
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
    // Register this entity in your DbContext (usually in the BusinessObjects folder of your project) with the "public DbSet<Versao> Versaos { get; set; }" syntax.
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    // You do not need to implement the INotifyPropertyChanged interface - EF Core implements it automatically.
    // (see https://learn.microsoft.com/en-us/ef/core/change-tracking/change-detection#change-tracking-proxies for details).
    //[NavigationItem("Cadastro")]
    [XafDisplayName("Versão")]
    public class Versao : BaseObject
    {
        public Versao()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
            this.Atividades = new ObservableCollection<Atividade>();
            this.AtividadesNaoAlocadas = new ObservableCollection<Atividade>();
            this.Inicio = DateTime.Now;
            this.Fim = DateTime.Now;
        }

        public override void OnCreated()
        {
            base.OnCreated();

            try
            {
                var listaAtividades = this.ObjectSpace.FindObject<List<Atividade>>( CriteriaOperator.Parse("VersaoId == " + this.ID));
                if (listaAtividades != null)
                {
                    this.AtividadesNaoAlocadas = listaAtividades;
                }
            }
            catch (Exception ex)
            { }
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
        [XafDisplayName("Código"), ToolTip("Código da versão")]
        [RuleRequiredField(DefaultContexts.Save)]
        [ModelDefault("EditMask", "0.00.00.0000")]
        [Column(TypeName = "varchar(50)")]
        public virtual string Codigo { get; set; }

        // Alternatively, specify more UI options:
        [XafDisplayName("Início"), ToolTip("Data inicio da versão")]
        [RuleRequiredField(DefaultContexts.Save)]
        [ModelDefault("EditMask", "dd/MM/yyyy")]
        [Column(TypeName = "smalldatetime")]
        public virtual DateTime Inicio { get; set; }

        [XafDisplayName("Fim"), ToolTip("Data fim da versão")]
        [RuleRequiredField(DefaultContexts.Save)]
        [ModelDefault("EditMask", "dd/MM/yyyy")]
        [Column(TypeName = "smalldatetime")]
        public virtual DateTime Fim { get; set; }

        [XafDisplayName("Qtde. Dias"), ToolTip("Quantidade de dias úteis na versão")]
        [RuleRequiredField(DefaultContexts.Save)]
        [Column(TypeName = "Int")]
        public virtual int? DiasUteis { get; set; }

        [XafDisplayName("Observação"), ToolTip("Observação sobre a versão")]
        [Column(TypeName = "varchar(5000)")]
        public virtual string Observacao { get; set; }

        // Collection property:
        [XafDisplayName("Atividades"), ToolTip("Atividades realizadas na versão")]
        public virtual IList<Atividade> Atividades { get; set; }

        //[DataSourceCriteria("[ColaboradorId] is null and [Finalizada] = 0")]
        // Collection property:
        [XafDisplayName("Atividades não Alocadas"), ToolTip("Atividades que não estão com ninguém")]
        [NotMapped]
        public virtual IList<Atividade> AtividadesNaoAlocadas { get; set; }

        [NonPersistent]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string FullName { get { return Codigo; } }

        public override Guid ID { get => base.ID; set => base.ID = value; }
    }
}