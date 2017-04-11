using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace _2Project
{
    
    public class clsDatabase
    {
        //***********************************************************
        //**  Procedure:  AcquireConnection()
        //**    Opens a connection using the default database
        //***********************************************************
        private static SqlConnection AcquireConnection()
        {
            return AcquireConnection("Payroll");
        }

        //***********************************************************
        //**  Procedure:  AcquireConnection()
        //**  Description:
        //**    Opens a connection using the specified connection
        //**  NOTE: Overloaded class to allow SQL connection creation
        //**        by external calls.
        //***********************************************************
        public static SqlConnection AcquireConnection(String strConnName)
        {
            SqlConnection cnSQL = null;
            Boolean blnErrorOccurred = false;

            //** Verify parameter
            if (strConnName.Trim().Length < 1)
            {
                blnErrorOccurred = true;
            }
            else if (ConfigurationManager.ConnectionStrings[strConnName] == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cnSQL = new SqlConnection();
                cnSQL.ConnectionString = ConfigurationManager.ConnectionStrings[strConnName].ToString();

                try
                {
                    cnSQL.Open();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return cnSQL;
            }
        }

        //***********************************************************
        //**  Procedure:  GetEmployees()
        //**    Retrieves all employees from the database
        //***********************************************************
        public static DataSet GetEmployees()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                //** Build command to execute stored procedure
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "GetAllEmployees";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();

                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        public static DataSet GetCurrEmployee(Int32 intEmpID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;

            //Verify parameter exists
            if (intEmpID < 1)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cnSQL = AcquireConnection();
                if (cnSQL == null)
                {
                    blnErrorOccurred = true;
                }
                else
                {
                    //** Build command to execute stored procedure
                    cmdSQL = new SqlCommand();
                    cmdSQL.Connection = cnSQL;
                    cmdSQL.CommandType = CommandType.StoredProcedure;
                    cmdSQL.CommandText = "GetPayrollByEmployee";

                    cmdSQL.Parameters.Add(new SqlParameter("@EmpID", SqlDbType.Int));
                    cmdSQL.Parameters["@EmpID"].Direction = ParameterDirection.Input;
                    cmdSQL.Parameters["@EmpID"].Value = intEmpID;

                    cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                    cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                    dsSQL = new DataSet();

                    try
                    {
                        daSQL = new SqlDataAdapter(cmdSQL);
                        daSQL.Fill(dsSQL);
                        daSQL.Dispose();
                    }
                    catch (Exception ex)
                    {
                        blnErrorOccurred = true;
                        dsSQL.Dispose();
                    }
                    finally
                    {
                        cmdSQL.Parameters.Clear();
                        cmdSQL.Dispose();
                        cnSQL.Close();
                        cnSQL.Dispose();
                    }
                }
            }
            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }
        public static DataSet GetEmployeeNames()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                //** Build command to execute stored procedure
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "GetEmployeeNames";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();

                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        public static Decimal GetEmployeePayrate(Int32 intEmpID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Decimal decPay = 0m;
            Int32 intRetCode;

            //Verify parameter exists
            if (intEmpID < 1)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cnSQL = AcquireConnection();
                if (cnSQL == null)
                {
                    blnErrorOccurred = true;
                }
                else
                {
                    //** Build command to execute stored procedure
                    cmdSQL = new SqlCommand();
                    cmdSQL.Connection = cnSQL;
                    cmdSQL.CommandType = CommandType.StoredProcedure;
                    cmdSQL.CommandText = "GetPayrateByID";

                    cmdSQL.Parameters.Add(new SqlParameter("@EmpID", SqlDbType.Int));
                    cmdSQL.Parameters["@EmpID"].Direction = ParameterDirection.Input;
                    cmdSQL.Parameters["@EmpID"].Value = intEmpID;

                    cmdSQL.Parameters.Add(new SqlParameter("@Payrate", SqlDbType.SmallMoney));
                    cmdSQL.Parameters["@Payrate"].Direction = ParameterDirection.Output;

                    cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                    cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        intRetCode = cmdSQL.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        blnErrorOccurred = true;
                    }
                    finally
                    {
                        cnSQL.Close();
                        cnSQL.Dispose();
                    }

                    if (!blnErrorOccurred)
                    {
                        if (cmdSQL.Parameters["@Payrate"].Value == DBNull.Value)
                        {
                            blnErrorOccurred = true;
                        }
                        else
                        {
                            decPay = Convert.ToDecimal(cmdSQL.Parameters["@Payrate"].Value);
                        }
                    }
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                }
            }
            if (blnErrorOccurred)
            {
                return -1.0m;
            }
            else
            {
                return decPay;
            }
        }
        public static Int32 InsertPayroll(Int32 intEmpID, string wkend, decimal hrsworked)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Decimal decPay = 0m;
            Int32 intRetCode;

            intRetCode = 0;
            //Verify parameter exists
            if (intEmpID < 1)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cnSQL = AcquireConnection();
                if (cnSQL == null)
                {
                    blnErrorOccurred = true;
                }
                else
                {
                    //** Build command to execute stored procedure
                    cmdSQL = new SqlCommand();
                    cmdSQL.Connection = cnSQL;
                    cmdSQL.CommandType = CommandType.StoredProcedure;
                    cmdSQL.CommandText = "InsertPayroll";

                    cmdSQL.Parameters.Add(new SqlParameter("@EmpID", SqlDbType.Int));
                    cmdSQL.Parameters["@EmpID"].Direction = ParameterDirection.Input;
                    cmdSQL.Parameters["@EmpID"].Value = intEmpID;

                    cmdSQL.Parameters.Add(new SqlParameter("@WeekEnding", SqlDbType.NChar));
                    cmdSQL.Parameters["@WeekEnding"].Direction = ParameterDirection.Input;
                    cmdSQL.Parameters["@WeekEnding"].Value = wkend;

                    cmdSQL.Parameters.Add(new SqlParameter("@HoursWorked", SqlDbType.Decimal));
                    cmdSQL.Parameters["@HoursWorked"].Direction = ParameterDirection.Input;
                    cmdSQL.Parameters["@HoursWorked"].Value = hrsworked;

                    cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                    cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        intRetCode = cmdSQL.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        blnErrorOccurred = true;
                    }
                    finally
                    {
                        cnSQL.Close();
                        cnSQL.Dispose();
                    }

                    if (!blnErrorOccurred)
                    {
                        if (cmdSQL.Parameters["@Payrate"].Value == DBNull.Value)
                        {
                            blnErrorOccurred = true;
                        }
                        else
                        {
                            decPay = Convert.ToDecimal(cmdSQL.Parameters["@Payrate"].Value);
                        }
                    }
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                }
            }
            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return intRetCode;
            }
        }

    }

}

