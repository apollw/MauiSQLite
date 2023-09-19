using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiSQLite.MVVM.Models;
using MauiSQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiSQLite.MVVM.ViewModels
{
    public partial class ViewModelAgenda:ObservableObject
    {
        [ObservableProperty]
        private List<ModelContato> _contatos;

        [ObservableProperty]
        private ModelContato _contatoAtual;

        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DisplayCommand { get; set; }
        public ViewModelAgenda(IAgendaService contatoRepository)
        {
            ContatoAtual = new ModelContato();

            AddCommand = new Command(async () =>
            {
                await contatoRepository.InitializeAsync();
                await contatoRepository.AddContato(ContatoAtual);
                await Refresh(contatoRepository);
            });

            UpdateCommand = new Command(async () =>
            {
                await contatoRepository.InitializeAsync();
                await contatoRepository.UpdateContato(ContatoAtual);
                await Refresh(contatoRepository);
            });

            DeleteCommand = new Command(async () =>
            {
            await contatoRepository.InitializeAsync();

            var resposta = await App.Current.MainPage.DisplayAlert("Alerta", "Confirmar Exclusão?", "Sim", "Não");
            if (resposta)
                await contatoRepository.DeleteContato(ContatoAtual);

                await Refresh(contatoRepository);
            });

            DisplayCommand = new Command(async () =>
            {
                await contatoRepository.InitializeAsync();
                await Refresh(contatoRepository);
            });
        }
        private async Task Refresh(IAgendaService contato)
        {
            Contatos = await contato.GetContatos();
        }
    }
}
