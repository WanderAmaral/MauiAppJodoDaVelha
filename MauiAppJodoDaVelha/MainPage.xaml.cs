namespace MauiAppJodoDaVelha
{
    public partial class MainPage : ContentPage
    {
        private string vez = "X";
        private Button[,] botoes;

        public MainPage()
        {
            InitializeComponent();
            InicializarTabuleiro();
        }

        private void InicializarTabuleiro()
        {
            botoes = new Button[3, 3]
            {
                
                { btn10, btn11, btn12 },
                { btn20, btn21, btn22 },
                { btn30, btn31, btn32 },
            };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.IsEnabled = false;
            btn.Text = vez;

            if (VerificarVitoria())
            {
                DisplayAlert("Parabéns", $"{vez} ganhou!", "Ok");
                ReiniciarJogo();
                return;
            }

            vez = vez == "X" ? "O" : "X";
        }

        private bool VerificarVitoria()
        {
            // Verifica linhas, colunas e diagonais
            for (int i = 0; i < 3; i++)
            {
                // Verifica linha
                if (botoes[i, 0].Text == vez && botoes[i, 1].Text == vez && botoes[i, 2].Text == vez)
                    return true;

                // Verifica coluna
                if (botoes[0, i].Text == vez && botoes[1, i].Text == vez && botoes[2, i].Text == vez)
                    return true;
            }

            // Verifica diagonais
            if (botoes[0, 0].Text == vez && botoes[1, 1].Text == vez && botoes[2, 2].Text == vez)
                return true;

            if (botoes[0, 2].Text == vez && botoes[1, 1].Text == vez && botoes[2, 0].Text == vez)
                return true;

            return false; // Não há vencedor.
        }


        private void ReiniciarJogo()
        {
            foreach (var btn in botoes)
            {
                btn.Text = ""; // Limpa o texto dos botões.
                btn.IsEnabled = true;   // Reabilita todos os botões.
            }

            vez = "X"; // Reinicia a vez para "X".
        }

    }
}
