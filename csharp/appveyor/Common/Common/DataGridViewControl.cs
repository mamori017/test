using System;
using System.Data;
using System.Windows.Forms;

namespace Common
{
    public class DataGridViewControl
    {
        public static void ChangeCheckState(Object sender,DataGridView dataGridView, int cellPos = 0)
        {
            Button btn = (Button)sender;
            bool checkState = false;
            bool parseRet = false;
            int btnTag = 0;

            try
            {
                parseRet = int.TryParse(btn.Tag.ToString(), out btnTag);

                if (parseRet)
                {
                    if(btnTag == 1)
                    {
                        checkState = true;
                    }
                    else
                    {
                        checkState = false;
                    }
                }
                else
                {
                    checkState = false;
                }

                if (dataGridView.RowCount > 0)
                {
                    for (int i = 0; i == dataGridView.RowCount - 1; i++)
                    {
                        dataGridView.Rows[i].Cells[cellPos].Value = checkState;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CheckboxSelectState(DataGridView dataGridView, int cellPos = 0)
        {
            try
            {
                if (dataGridView.RowCount > 0)
                {
                    for (int i = 0; i < dataGridView.RowCount - 1; i++)
                    {
                        if (dataGridView.Rows[i].Cells[cellPos].Value != null)
                        {
                            if ((bool)dataGridView.Rows[i].Cells[cellPos].Value == true)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string[] GetCheckboxSelectValue(DataGridView dataGridView, int cellPos = 0)
        {
            String[] strId = null;
            int intCnt = 0;

            try
            {
                if(dataGridView.RowCount > 0){
                    for(int i = 0; i < dataGridView.RowCount - 1; i++)
                    {
                        if((bool)dataGridView.Rows[i].Cells[0].Value == true)
                        {
                            Array.Resize(ref strId, i);
                            strId[i] = (String)dataGridView.Rows[i].Cells[cellPos].Value;
                            intCnt ++;
                        }
                    }
                }
                return strId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ChangeReadOnlyCell(DataGridView dataGridView, bool firstCellTarget = false)
        {
            try
            {
                if (dataGridView.RowCount > 0)
                {
                    for(int i =0; i < dataGridView.ColumnCount - 1; i++)
                    {
                        if(firstCellTarget == false && i != 0)
                        {
                            dataGridView.Columns[i].ReadOnly = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void FilterViewChange(DataGridView dataGridView, String filterQuery)
        {
            BindingSource objBind;
            DataTable objData;

            try
            {
                objData = (DataTable)dataGridView.DataSource;

                if(objData != null)
                {
                    objBind = new BindingSource
                    {
                        DataSource = objData,
                        Filter = filterQuery   
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objBind = null;
                objData = null;
            }
        }

        public static bool CreateDataGridView(DataTable objDataTable, DataGridView objDataGridView , bool vblnCheckFlg = false, int checkFlgOrdinal = 0)
        {
            DataGridViewCheckBoxColumn objColumn = null;
            try
            {
                if (objDataTable.Rows.Count > 0)
                {
                    objDataGridView.DataSource = null;

                    if(vblnCheckFlg == true)
                    {
                        objColumn = (DataGridViewCheckBoxColumn)objDataGridView.Columns[checkFlgOrdinal]; 
                    }
                    objDataGridView.DataSource = objDataTable;
                    ChangeReadOnlyCell(objDataGridView);
                }
                else
                {
                    objDataGridView.DataSource = null;
                }

                objDataGridView.Refresh();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objColumn = null;
            }
        }
    }
}
