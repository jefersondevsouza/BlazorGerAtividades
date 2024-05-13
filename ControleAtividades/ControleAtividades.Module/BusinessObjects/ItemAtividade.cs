using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
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
    // Register this entity in your DbContext (usually in the BusinessObjects folder of your project) with the "public DbSet<Atividade> Atividades { get; set; }" syntax.
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("Name")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    // You do not need to implement the INotifyPropertyChanged interface - EF Core implements it automatically.
    // (see https://learn.microsoft.com/en-us/ef/core/change-tracking/change-detection#change-tracking-proxies for details).

    //quanto a atividade estiver finalizada
    [Appearance("GreenActiveObject", AppearanceItemType = "ViewItem", TargetItems = "*",
                                  Criteria = "[Finalizada] = 1", Context = "ListView",
                                  BackColor = "#c0de5d", FontColor = "Black", Priority = 4)]

    //quando a atividade estiver teoricamente atrasada
    //[Appearance("RedActiveObject", AppearanceItemType = "ViewItem", TargetItems = "*",
    //                              Criteria = "[ColaboradorId] is not null and [Finalizada] = 0 and [DataPrevisaoFim] Is Not Null And [DataPrevisaoFim] < GetDate()", Context = "ListView",
    //                              BackColor = "#ff7474", FontColor = "Black", Priority = 3)]

    //quando a atividade estiver alocada e estiver no prazo
    [Appearance("BlueActiveObject", AppearanceItemType = "ViewItem", TargetItems = "*",
                                  Criteria = "[ColaboradorId] is not null and [Finalizada] = 0", Context = "ListView",
                                  //Criteria = "[ColaboradorId] is not null and [Finalizada] = 0 And [DataPrevisaoFim] is null And [DataPrevisaoFim] >= GetDate()", Context = "ListView",
                                  BackColor = "#9dd3df", FontColor = "Black", Priority = 2)]

    //quando a atividade estiver aberta
    [Appearance("YellowActiveObject", AppearanceItemType = "ViewItem", TargetItems = "*",
                                  Criteria = "[ColaboradorId] is null and [Finalizada] = 0", Context = "ListView",
                                  BackColor = "#ffffc0", FontColor = "Black", Priority = 1)]
    //[NavigationItem("Cadastro")]
    [XafDisplayName("ItemAtividade")]
    public class ItemAtividade : BaseObject
    {
        public ItemAtividade()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }

        public override void OnCreated()
        {
            base.OnCreated();
            DateTime minDate = new DateTime(1900, 01, 01);
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

        [XafDisplayName("Data Lançamento"), ToolTip("Data de lançamento do item atividade")]
        [RuleRequiredField(DefaultContexts.Save)]
        [ModelDefault("DisplayFormat", "{0: dd/MM/yyyy HH:mm}")]
        [ModelDefault("EditMask", "dd/MM/yyyy HH:mm")]
        [Column(TypeName = "smalldatetime")]
        public virtual DateTime DataLancamento { get; set; }

        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public virtual Guid AtividadeId { get; set; }

        [XafDisplayName("Atividade")]
        //[Association("FormaPagamento_Pessoa", "", "", IsForeignKey = true)]
        [ForeignKey("AtividadeId")]
        public virtual Atividade Atividade { get; set; }

        [XafDisplayName("Data Inicio"), ToolTip("Data do início da atividade")]
        [Column(TypeName = "smalldatetime")]
        [ModelDefault("DisplayFormat", "{0: dd/MM/yyyy HH:mm}")]
        [ModelDefault("EditMask", "dd/MM/yyyy HH:mm")]
        public virtual DateTime? DataInicio { get; set; }

        [XafDisplayName("Data Finalizada"), ToolTip("Data de finalização da atividade")]
        [Column(TypeName = "smalldatetime")]
        [ModelDefault("DisplayFormat", "{0: dd/MM/yyyy HH:mm}")]
        [ModelDefault("EditMask", "dd/MM/yyyy HH:mm")]
        public virtual DateTime? DataFim { get; set; }

        [XafDisplayName("Observação"), ToolTip("Observação da atividade")]
        [Column(TypeName = "varchar(5000)")]
        public virtual string? Observacao { get; set; }

    }
}