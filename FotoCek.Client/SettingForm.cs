using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FotoCek.Business.DependencyResolver;
using FotoCek.DAL.Abstract;
using Ninject;

namespace FotoCek.Client
{
    public partial class SettingForm : Form
    {
        private IKernel _kernel;
        private ICameraDal _cameraManager;

        public SettingForm()
        {
            InitializeComponent();
            _kernel = new StandardKernel(new BusinessModule());
            _cameraManager = _kernel.Get<ICameraDal>();
        }
    }
}
