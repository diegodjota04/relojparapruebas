using System.Windows.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using LogicaDeNegocios;
using System.Security.Cryptography.X509Certificates;


namespace Reloj_para_pruebas
{
    public partial class Reloj : Form
    {
        TiempoLogica tiempoLogica;

        public Reloj()
        {
        InitializeComponent(); 
        FormClosing += Reloj_FormClosing;
        tiempoLogica = new TiempoLogica();
        }
        
        private void Timer1_Tick(object sender, System.EventArgs e)
        {
            HoraActual.Text = DateTime.Now.ToString("hh:mm:ss" + " "+"tt");//muestra la hora actual
        }

       private void IniciarPrueba_Click(object sender, EventArgs e)//al seleccionar el botón deben suceder las acciones
        {
            if (comboBoxAsignaturas.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una asignatura", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                comboBoxAsignaturas.Enabled = false;//Bloquea el comboBox para que no se pueda reseleccionar la asignatura
                IniciarPrueba.Enabled = false;//Bloquea el botón para que no esté disponible 
                RadioButtonPrueba1.Enabled = false; //Bloquea el botón para que no esté disponible 
                RadioButtonPrueba2.Enabled = false;//Bloquea el botón para que no esté disponible 
                tiempoLogica.ActualizarTiempo (DateTime.Now);//Actualiza todos los campos
                HoraDeInicio.Text = tiempoLogica.ObtenerHoraInicio().ToString("hh:mm" + " " + "tt");//fija la hora de inicio
                if (RadioButtonPrueba1.Checked == true)
                {
                    HoraFinalizacionRegular.Text = tiempoLogica.ObtenerHoraFinalizacionRegular().ToString("hh:mm" + " " + "tt");//indica la hora de finalización para estudiantes regulares
                    HoraFinalizacionApoyos.Text = tiempoLogica.ObtenerHoraFinalizacionApoyos().ToString("hh:mm" + " " + "tt");//indica la hora de finalización para estudiantes con apoyo educativo
                }
                else
                {
                    HoraFinalizacionRegular.Text = tiempoLogica.ObtenerHoraFinalizacionRegular2().ToString("hh:mm" + " " + "tt");//indica la hora de finalización para estudiantes regulares
                    HoraFinalizacionApoyos.Text = tiempoLogica.ObtenerHoraFinalizacionApoyos2().ToString("hh:mm" + " " + "tt");//indica la hora de finalización para estudiantes con apoyo educativo
                }
            }
        }
        private void Reloj_FormClosing(object sender, CancelEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está realmente seguro de que desea salir?", "Confirmar Sí/No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.No)
            {
                // Confirma que desea salir y abandona la aplicación, limpia los datos
                e.Cancel = true;
            }
        }


        private void BotonReinicio_Click(object sender,EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea reiniciar el reloj?", "Confirmar Sí/No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                LimpiarCampos(this);//limpia los campos sin salir de la aplicación
                comboBoxAsignaturas.Enabled = true;//Habilita los controles para volver a empezar
                IniciarPrueba.Enabled = true;
                RadioButtonPrueba1.Enabled = true;
                RadioButtonPrueba1.Checked = true;
                RadioButtonPrueba2.Enabled = true;
            }
            else
            {
                this.Close();
            }
        }
        private void BotonFinalizar_Click(object sender,EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está realmente seguro de que desea salir?", "Confirmar Sí/No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                // Confirma que desea salir y abandona la aplicación, limpia los datos
                Dispose(true);
                Application.Exit();
            }
            else
            {
                this.Close();
            }
        }

        private void RadioButtonPrueba1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButtonPrueba2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void LimpiarCampos(Control parent)//Función que limpia todos los controles del formulario
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                else if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = -1;
                }
                else if (c is RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                }
                else if (c.HasChildren)
                {
                    LimpiarCampos(c);
                }
            }
        }
    }
}
