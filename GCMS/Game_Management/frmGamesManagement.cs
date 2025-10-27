using GCMS.User_Control;
using GCMS_Business;
using GCMS_Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCMS.Game_Manaegement
{
    public partial class frmGamesManagement : Form
    {
        private List<clsGames> _GamesList;
        private List<clsGameTypes> _GameTypes;
        public frmGamesManagement()
        {
            InitializeComponent();
        }

        private void _FillComboBoxWithGameTypes()
        {
            _GameTypes = clsGameTypes.GetGamesTypesList();
            cbGameTypes.DataSource = _GameTypes;
            cbGameTypes.DisplayMember = "GameTypeName";
            cbGameTypes.ValueMember = "GameTypeID";
        }
        //on games manaegement load
        private  void frmGamesManaegement_Load(object sender, EventArgs e)
        {
            //Get the games and fill the combo box with game types
            _GamesList = clsGames.GetGamesList();
            _FillComboBoxWithGameTypes();


            if(_GamesList.Count != 0)
            {
                //Clear the flow layout panel and the dictionanry
                flpGames.Controls.Clear();

                //loop through all items
                foreach (clsGames Game in _GamesList)
                {
                    ctrlGameManagement GameControl = new ctrlGameManagement(Game);
                    GameControl.Margin = new Padding(10); // space between controls
                    flpGames.Controls.Add(GameControl);

                }

            }
        }


        //check if the new game info is correct
        private bool IsValidGameInfo()
        {
            if (clsValidationHelper.IsEmptyOrWhiteSpaces(tbGameName.Text))
            {
                MessageBox.Show("Game name should not be empty ! ,please fill the game name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (clsValidationHelper.ContainsSymbols(tbGameName.Text))
            {
                MessageBox.Show("Game name should not contain symbols!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!clsValidationHelper.IsValidCharacterRange(20, tbGameName.Text))
            {
                MessageBox.Show("Game name should not be more than 20 character !", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (nudGameRate.Value == 0)
            {
                MessageBox.Show("Game Rate should be above 0 !", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            return true;
        }
        //Adding new game
        private void btnAddNewGame_Click(object sender, EventArgs e)
        {
            if (IsValidGameInfo())
            {
                clsGames Game = new clsGames();

                Game.GameTypeID = (int)cbGameTypes.SelectedValue;
                Game.GameName = tbGameName.Text;
                Game.Rate = nudGameRate.Value;
                Game.Status = rbActive.Checked;

                if(Game.Save())
                {
                    //add the new game to the flow layout panel
                    ctrlGameManagement GameControl = new ctrlGameManagement(Game);
                    GameControl.Margin = new Padding(10); // space between controls
                    flpGames.Controls.Add(GameControl);

                    MessageBox.Show("New game is added", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                    MessageBox.Show("Coudn't add new game, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
