/* ****************************************************************************
 * 
 * Copyright (c) 2012 Vikas Goyal. All rights reserved.
 * 
 * This file is part of extjs-mvc-templates-for-visual-studio.
 *
 * This is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Ext.Direct.Mvc is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with Ext.Direct.Mvc.  If not, see <http://www.gnu.org/licenses/>.
 *
 * ***************************************************************************/
#region Using Directives

using System;
using System.IO;
using System.Windows.Forms;
using EnvDTE;
using ExtJs.Helpers;
using Microsoft.Practices.RecipeFramework;
using Microsoft.Practices.RecipeFramework.Library;

#endregion

namespace ExtJs.Actions
{
    internal class AddProjectItemAction : ConfigurableAction
    {
        #region Input Properties

        [Input(Required = true)]
        public string Content { get; set; }

        [Input]
        public bool Open { get; set; }

        [Input(Required = true)]
        public Project Project { get; set; }

        [Input(Required = true)]
        public string TargetFileName { get; set; }

        [Input]
        public bool IsValid { get; set; }

        #endregion

        #region Output Properties

        [Output]
        public ProjectItem ProjectItem { get; set; }

        #endregion

        #region IAction Members Implementations
        public override void Execute()
        {
            if (!IsValid)
            {
                return;
            }

            try
            {
                var service = base.GetService<DTE>(true);
                var selectedFolder = (ProjectItem)DteHelper.GetTarget(service);
                CreateProjectItem(selectedFolder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ErrorMessages.GeneralError, ex.Message), MessageType.Error,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                IsValid = false;
            }
        }

        public void Execute(ProjectItem selectedFolder)
        {
            CreateProjectItem(selectedFolder);
        }

        private void CreateProjectItem(ProjectItem selectedFolder)
        {
            string tempFileName = Path.GetTempFileName();
            using (var writer = new StreamWriter(tempFileName, false))
            {
                writer.WriteLine(Content);
            }

            ProjectItem = selectedFolder.ProjectItems.AddFromTemplate(tempFileName, TargetFileName);

            if (Open)
            {
                Window window = ProjectItem.Open("{00000000-0000-0000-0000-000000000000}");
                window.Visible = true;
                window.Activate();
            }
            File.Delete(tempFileName);
        }

        

        public override void Undo()
        {
            if (ProjectItem != null)
            {
                ProjectItem.Delete();
            }
        } 
        #endregion
    }
}