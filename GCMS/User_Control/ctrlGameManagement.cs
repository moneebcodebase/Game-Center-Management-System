using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GCMS_Business;
using GCMS_Infrastructure;

namespace GCMS.User_Control
{
    public partial class ctrlGameManagement : UserControl
    {
        //private data memebers used in this control
        private clsGames _Game;

        //Constructor that only accept clsGames object
        public ctrlGameManagement(clsGames Game)
        {
            InitializeComponent();

            _Game = Game;
        }


        //private method that filles the Game manaegment control with data
        private void _FillControlWithData()
        {
            gbGameType.Text = _Game.GameType.GameTypeName;
            tbGameName.Text = _Game.GameName;
            nudGameRate.Value = _Game.Rate;

            if(_Game.Status ==true)
                rbActivate.Checked = true;
            else
                rbDeactivate.Checked = true;


        }
        //Contorl Load
        private void ctrlGameManaegement_Load(object sender, EventArgs e)
        {
            _FillControlWithData();
        }


        private bool _IsValidGameData()
        {
            if(clsValidationHelper.IsEmptyOrWhiteSpaces(tbGameName.Text))
            {
                MessageBox.Show("Game name should not be empty ! ,please fill the game name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (clsValidationHelper.ContainsSymbols(tbGameName.Text))
            {
                MessageBox.Show("Game name should not contain symbols!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!clsValidationHelper.IsValidCharacterRange(20,tbGameName.Text))
            {
                MessageBox.Show("Game name should not be more than 20 character !", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(nudGameRate.Value == 0)
            {
                MessageBox.Show("Game Rate should be above 0 !", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            return true;
        }
        //Save the update
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_IsValidGameData())
            {
                _Game.GameName = tbGameName.Text;
                _Game.Rate = nudGameRate.Value;

                if (rbActivate.Checked)
                    _Game.Status = true;
                else
                    _Game.Status = false;

                if(_Game.Save())
                    MessageBox.Show("Game has been updated.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Failed to save updates.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
