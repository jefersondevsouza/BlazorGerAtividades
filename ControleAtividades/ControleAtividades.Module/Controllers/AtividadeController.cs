using ControleAtividades.Module.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ControleAtividades.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class AtividadeController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public AtividadeController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(Atividade);
            TargetViewType = ViewType.DetailView;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            this.ObjectSpace.ObjectChanged += ObjectSpace_ObjectChanged;
            // Perform various tasks depending on the target View.
        }

        private bool ignorarEvento = false;
        private void ObjectSpace_ObjectChanged(object sender, ObjectChangedEventArgs e)
        {
            if (ignorarEvento)
            {
                ignorarEvento = false;
                return;
            }

            if (e.PropertyName.Equals("ColaboradorId"))
            {
                var atividade = (Atividade)this.View.CurrentObject;
                if (atividade.ColaboradorId.HasValue)
                {
                    if (!atividade.DataDirecionamento.HasValue)
                    {
                        this.ignorarEvento = true;
                        atividade.DataDirecionamento = DateTime.Now;
                    }
                }
            }
            else if (e.PropertyName.Equals("DataFinalizada"))
            {
                var atividade = (Atividade)this.View.CurrentObject;
                if (atividade.DataFinalizada.HasValue)
                {
                    if (atividade.DataFinalizada.Value.Date == DateTime.Today.Date)
                    {
                        this.ignorarEvento = true;
                        atividade.DataFinalizada = DateTime.Now;
                    }

                    DateTime dataBase = new DateTime(1900, 01, 01);
                    if (atividade.DataFinalizada > dataBase)
                    {
                        atividade.Finalizada = true;
                    }
                    else
                    {
                        atividade.Finalizada = false;
                    }
                }
                else
                {
                    atividade.Finalizada = false;
                }
            }
            else if (e.PropertyName.Equals("TempoHoraPrevisao"))
            {
                var atividade = (Atividade)this.View.CurrentObject;
                if (atividade.TempoHoraPrevisao != null && atividade.TempoHoraPrevisao > 0)
                {
                    if (!atividade.DataPrevisaoFim.HasValue)
                    {
                        if (atividade.DataDirecionamento.HasValue)
                        {
                            if (atividade.ColaboradorId.HasValue)
                            {
                                var colaborador = this.ObjectSpace.FirstOrDefault<Colaborador>(p => p.ID == atividade.ColaboradorId);
                                if (colaborador != null)
                                {
                                    var arrayInicio = colaborador.HoraInicial.Split(":"); 
                                    var arrayFim = colaborador.HoraFinal.Split(":");

                                    var arrayInicioIntervalo = colaborador.HoraInicialIntervalo.Split(":");
                                    var arrayFimIntervalo = colaborador.HoraFinalIntervalo.Split(":");

                                    TimeSpan inicio = new TimeSpan(int.Parse(arrayInicio[0]), int.Parse(arrayInicio[1]), 0);
                                    TimeSpan fim = new TimeSpan(int.Parse(arrayFim[0]), int.Parse(arrayFim[1]), 0);
                                    TimeSpan inicioIntervalo = new TimeSpan(int.Parse(arrayInicioIntervalo[0]), int.Parse(arrayInicioIntervalo[1]), 0);
                                    TimeSpan fimIntervalo = new TimeSpan(int.Parse(arrayFimIntervalo[0]), int.Parse(arrayFimIntervalo[1]), 0);

                                    DateTime dataPrevistaFim = atividade.DataDirecionamento.Value;
                                    for (int i = 1; i <= atividade.TempoHoraPrevisao; i++)
                                    {
                                        for (int minuto = 1; minuto <= 60; minuto++)
                                        {
                                            if (dataPrevistaFim >= dataPrevistaFim.Date.Add(fim))
                                            {
                                                dataPrevistaFim = dataPrevistaFim.AddDays(1).Date.Add(inicio);
                                                if (dataPrevistaFim.DayOfWeek == DayOfWeek.Saturday)
                                                {
                                                    dataPrevistaFim = dataPrevistaFim.AddDays(1);
                                                }

                                                if (dataPrevistaFim.DayOfWeek == DayOfWeek.Sunday)
                                                {
                                                    dataPrevistaFim = dataPrevistaFim.AddDays(1);
                                                }
                                            }
                                            else if (dataPrevistaFim >= dataPrevistaFim.Date.Add(inicioIntervalo) && dataPrevistaFim <= dataPrevistaFim.Date.Add(fimIntervalo))
                                            {
                                                dataPrevistaFim = dataPrevistaFim.AddHours(1);
                                            }

                                            dataPrevistaFim = dataPrevistaFim.AddMinutes(1);
                                        }
                                    }

                                    atividade.DataPrevisaoFim = dataPrevistaFim;


                                    //colaborador.NumeroHorasDia
                                }
                            }

                            //atividade.DataPrevisaoFim = atividade.DataDirecionamento.Value.AddHours(atividade.TempoHoraPrevisao);
                        }
                    }
                }
            }
            //else if (e.PropertyName.Equals("DataDirecionamento"))
            //{
            //    var atividade = (Atividade)this.View.CurrentObject;
            //    if (atividade.DataDirecionamento.HasValue)
            //    {
            //        if (atividade.DataDirecionamento.Value.Date == DateTime.Today.Date)
            //        {
            //            this.ignorarEvento = true;
            //            atividade.DataDirecionamento = DateTime.Now;

            //            //RaisePropertyChangedEvent("Oid");
            //            //this.View.Refresh();
            //        }
            //    }
            //}
            //else if (e.PropertyName.Equals("DataPrevisaoFim"))
            //{
            //    var atividade = (Atividade)this.View.CurrentObject;
            //    if (atividade.DataPrevisaoFim.HasValue)
            //    {
            //        if (atividade.DataPrevisaoFim.Value.Date == DateTime.Today.Date)
            //        {
            //            this.ignorarEvento = true;
            //            atividade.DataPrevisaoFim = DateTime.Now;
            //        }
            //    }
            //}
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
