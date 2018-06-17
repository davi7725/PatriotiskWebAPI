using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using PatriotiskSelskabWebAPI.Models;

namespace PatriotiskSelskabWebAPI
{
    public static class DataBaseConnector
    {
        private static string connectionString = @"Server=DESKTOP-MSP9QG8\SQLEXPRESS;Database=PatriotiskSelskab;Trusted_Connection=true";

        public static List<int> GetYears()
        {
            List<int> years = new List<int>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand("select distinct FieldBlockYear from FieldBlock order by FieldBlockYear DESC", connection);
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            years.Add(reader.GetInt32(0));
                        }
                    }
                }
                catch (SqlException e)
                {

                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return years;
        }

        internal static SubBlock GetSubBlock(int subblockid)
        {
            SubBlock subBlock = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand("select * from SubBlock, TrialType  WHERE SubBlockID=@SubBlockID", connection);
                    cmdGetCustomers.Parameters.Add(new SqlParameter("@SubBlockID", subblockid));
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            subBlock = new SubBlock(reader.GetInt32(0), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetString(10), new TrialType(reader.GetString(12)), null);
                        }
                    }
                }
                catch (SqlException e)
                {
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return subBlock;
        }

        internal static IEnumerable<Crop> GetAllWeeds()
        {
            List<Crop> crops = new List<Crop>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand("select * from Crop order by CropName ASC", connection);
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            crops.Add(new Crop(reader.GetString(1)));
                        }
                    }
                }
                catch (SqlException e)
                {

                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return crops;
        }

        internal static IEnumerable<TopResult> GetTopResults()
        {
            List<TopResult> topresults = new List<TopResult>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand("select TrialType.Name, TopResult.TrialGroupID from TopResult,TrialType where TrialType.TrialTypeID = TopResult.TrialTypeID", connection);
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            topresults.Add(new TopResult(reader.GetString(0), reader.GetInt32(1)));
                        }
                    }
                }
                catch (SqlException e)
                {

                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return topresults;
        }

        internal static IEnumerable<int> GetCropYears(int trialtypeid,int cropid)
        {
            List<int> years = new List<int>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand(" select distinct FieldBlockYear from FieldBlock,SubBlock,TrialGroup,Crop where TrialTypeID = @TrialTypeId and FieldBlock.FieldBlockID = SubBlock.FieldBlockID and SubBlock.SubBlockID = TrialGroup.SubBlockID and Crop.CropID = @CropId order by FieldBlockYear DESC", connection);
                    cmdGetCustomers.Parameters.Add(new SqlParameter("@TrialTypeId", trialtypeid));
                    cmdGetCustomers.Parameters.Add(new SqlParameter("@CropId", cropid));
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            years.Add(reader.GetInt32(0));
                        }
                    }
                }
                catch (SqlException e)
                {

                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return years;
        }

        internal static IEnumerable<Crop> GetTrialTypeCrops(int trialtypeid)
        {
            List<Crop> crops = new List<Crop>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand("select distinct Crop.CropID, Crop.CropName from SubBlock,TrialGroup,Crop where TrialTypeID = @TrialTypeId and SubBlock.SubBlockID = TrialGroup.SubBlockID and Crop.CropID = TrialGroup.CropID order by CropName ASC", connection);
                    cmdGetCustomers.Parameters.Add(new SqlParameter("@TrialTypeId", trialtypeid));
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Crop c = new Crop(reader.GetString(1));
                            c.ID = reader.GetInt32(0);
                            crops.Add(c);
                        }
                    }
                }
                catch (SqlException e)
                {

                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return crops;
        }

        internal static IEnumerable<TrialType> GetTrialTypes()
        {
            List<TrialType> trialtypes = new List<TrialType>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand("select * from TrialType order by Name ASC", connection);
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            TrialType t = new TrialType(reader.GetString(1));
                            t.Id = reader.GetInt32(0);
                            trialtypes.Add(t);
                        }
                    }
                }
                catch (SqlException e)
                {

                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return trialtypes;
        }

        internal static FieldBlock GetSubBlockFieldBlock(int subblockid)
        {
            FieldBlock fieldBlock = null;
            int fieldblockid = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand("select FieldBlockID from SubBlock WHERE SubBlockId = @SubBlockId", connection);
                    cmdGetCustomers.Parameters.Add(new SqlParameter("@SubBlockId", subblockid));
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            fieldblockid = reader.GetInt32(0);
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand("select * from FieldBlock WHERE FieldBlockID = @FieldBlockID", connection);
                    cmdGetCustomers.Parameters.Add(new SqlParameter("@FieldBlockID", fieldblockid));
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            fieldBlock = new FieldBlock(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), null);
                        }
                    }
                }
                catch (SqlException e)
                {

                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return fieldBlock;
        }

        internal static SubBlock GetTrialGroupSubBlock(int trialgroupid)
        {
            SubBlock subBlock = null;
            int subblockid = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand("select SubBlockID from TrialGroup WHERE TrialGroupID = @TrialGroupId", connection);
                    cmdGetCustomers.Parameters.Add(new SqlParameter("@TrialGroupId", trialgroupid));
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            subblockid = reader.GetInt32(0);
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand("select * from SubBlock, TrialType  WHERE SubBlockID=@SubBlockID", connection);
                    cmdGetCustomers.Parameters.Add(new SqlParameter("@SubBlockID", subblockid));
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            subBlock = new SubBlock(reader.GetInt32(0), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetString(10), new TrialType(reader.GetString(12)), null);
                        }
                    }
                }
                catch (SqlException e)
                {

                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return subBlock;
        }

        internal static TrialGroup GetTrialGroup(int trialgroupid)
        {
            TrialGroup trialGroup = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmdGetCustomers = new SqlCommand("select * from TrialGroup, Crop  WHERE  TrialGroupID = @TrialGroupId AND Crop.CropID = TrialGroup.CropID", connection);
                    cmdGetCustomers.Parameters.Add(new SqlParameter("@TrialGroupId", trialgroupid));
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            trialGroup = new TrialGroup(reader.GetInt32(0), new Crop(reader.GetString(6)), reader.GetInt32(3), reader.GetString(4), null);
                        }
                    }
                }
                catch (SqlException e)
                {
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return trialGroup;
        }

        internal static FieldBlock GetYearFieldBlock(int fieldblockid)
        {
            FieldBlock fieldBlock = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand("select * from FieldBlock WHERE FieldBlockID = @FieldBlockID", connection);
                    cmdGetCustomers.Parameters.Add(new SqlParameter("@FieldBlockID", fieldblockid));
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            fieldBlock = new FieldBlock(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), null);
                        }
                    }
                }
                catch (SqlException e)
                {

                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return fieldBlock;
        }

        public static List<FieldBlock> GetYearFieldBlocks(int year)
        {
            List<FieldBlock> fieldBlocks = new List<FieldBlock>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand("select * from FieldBlock WHERE FieldBlockYear = @FieldBlockYear order by BlockChar ASC", connection);
                    cmdGetCustomers.Parameters.Add(new SqlParameter("@FieldBlockYear", year));
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            fieldBlocks.Add(new FieldBlock(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5), null));
                        }
                    }
                }
                catch (SqlException e)
                {

                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return fieldBlocks;
        }

        public static List<SubBlock> GetSubBlocks(int fieldBlockID)
        {
            List<SubBlock> subBlocks = new List<SubBlock>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand("select * from SubBlock, TrialType  WHERE FieldBlockID = @FieldBlockId AND SubBlock.TrialTypeID=TrialType.TrialTypeID order by SubBlockChar ASC", connection);
                    cmdGetCustomers.Parameters.Add(new SqlParameter("@FieldBlockId", fieldBlockID));
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            subBlocks.Add(new SubBlock(reader.GetInt32(0), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetString(10), new TrialType(reader.GetString(12)), null));
                        }
                    }
                }
                catch (SqlException e)
                {
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return subBlocks;
        }
        public static List<TrialGroup> GetTrialGroups(int subBlockID)
        {
            List<TrialGroup> trialGroups = new List<TrialGroup>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand("select * from TrialGroup, Crop  WHERE  SubBlockID = @SubBlockId AND Crop.CropID = TrialGroup.CropID order by TrialGroupNr", connection);
                    cmdGetCustomers.Parameters.Add(new SqlParameter("@SubBlockId", subBlockID));
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            trialGroups.Add(new TrialGroup(reader.GetInt32(0), new Crop(reader.GetString(6)), reader.GetInt32(3), reader.GetString(4), null));
                        }
                    }
                }
                catch (SqlException e)
                {
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return trialGroups;
        }

        public static List<Treatment> GetTrialGroupTreatments(int trialGroupID)
        {
            List<Treatment> treatments = new List<Treatment>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmdGetCustomers = new SqlCommand("select * from Treatment,TreatmentType where TrialGroupID = @TrialGroupId AND Treatment.TreatmentTypeID = TreatmentType.TreatmentTypeID", connection);
                    cmdGetCustomers.Parameters.Add(new SqlParameter("@TrialGroupId", trialGroupID));
                    SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DateTime date = reader.IsDBNull(3) ? new DateTime() : reader.GetDateTime(3);
                            treatments.Add(new Treatment(reader.GetInt32(0), new TreatmentType(reader.GetString(7)), date, reader.GetString(4), reader.GetString(5), null));
                        }
                    }
                }
                catch (SqlException e)
                {
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            foreach (Treatment t in treatments)
            {
                List<TreatmentProduct> products = new List<TreatmentProduct>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        SqlCommand cmdGetCustomers = new SqlCommand("select * from Treatment_Product, Product where TreatmentID = @TreatmentId AND Treatment_Product.ProductID = Product.ProductID", connection);
                        cmdGetCustomers.Parameters.Add(new SqlParameter("@TreatmentId", t.TreatmentID));
                        SqlDataReader reader = cmdGetCustomers.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                products.Add(new TreatmentProduct(new Product(reader.GetString(7), "", new ProductCategory("")), (double)reader.GetDecimal(3), new UnitType(reader.GetString(4)), reader.GetBoolean(5), null));
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
                t.Products = products;
            }

            return treatments;
        }

        public static void AddFieldBlock(FieldBlock fieldblock)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                transaction = connection.BeginTransaction("");

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText =
                        "Insert into FieldBlock (BlockChar, FieldBlockYear,FieldBlockLength,FieldBlockWidth,Comment) OUTPUT INSERTED.FieldBlockID VALUES (@BlockChar,@FieldBlockYear,@FieldBlockLength,@FieldBlockWidth,@Comment)";
                    command.Parameters.Add(new SqlParameter("@BlockChar", fieldblock.BlockChar));
                    command.Parameters.Add(new SqlParameter("@FieldBlockYear", fieldblock.FieldBlockYear));
                    command.Parameters.Add(new SqlParameter("@FieldBlockLength", fieldblock.FieldBlockLength));
                    command.Parameters.Add(new SqlParameter("@FieldBlockWidth", fieldblock.FieldBlockWidth));
                    command.Parameters.Add(new SqlParameter("@Comment", fieldblock.Comment));
                    int fieldBlockID = (int)command.ExecuteScalar();
                    command.Parameters.Clear();
                    foreach (SubBlock subB in fieldblock.SubBlocks)
                    {
                        command.CommandText = "SP_InsertSubBlock";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@FieldBlockID", fieldBlockID));
                        command.Parameters.Add(new SqlParameter("@SubBlockChar", subB.SubBlockChar));
                        command.Parameters.Add(new SqlParameter("@AmountOfTrialGroups", subB.AmountOfTrialGroups));
                        command.Parameters.Add(new SqlParameter("@LastNrOfTrialGroup", subB.LastNrOfTrialGroup));
                        command.Parameters.Add(new SqlParameter("@SubBlockLength", subB.SubBlockLength));
                        command.Parameters.Add(new SqlParameter("@SubBlockWidth", subB.SubBlockWidth));
                        command.Parameters.Add(new SqlParameter("@PosL", subB.PosL));
                        command.Parameters.Add(new SqlParameter("@PosW", subB.PosW));
                        command.Parameters.Add(new SqlParameter("@TrialTypeName", subB.SubBlockTrialType.Name));
                        command.Parameters.Add(new SqlParameter("@Comment", subB.Comment));
                        int subBlockID = (int)command.ExecuteScalar();

                        command.Parameters.Clear();

                        foreach (TrialGroup trialG in subB.TrialGroups)
                        {
                            command.CommandText = "SP_InsertTrialGroup";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add(new SqlParameter("@SubBlockID", subBlockID));
                            command.Parameters.Add(new SqlParameter("@CropName", trialG.TrialGroupCrop.Name));
                            command.Parameters.Add(new SqlParameter("@TrialGroupNr", trialG.TrialGroupNr));
                            command.Parameters.Add(new SqlParameter("@Comment", trialG.Comment));
                            int trialGroupID = (int)command.ExecuteScalar();

                            command.Parameters.Clear();
                            if (trialG.Treatments != null)
                            {
                                foreach (Treatment treatment in trialG.Treatments)
                                {
                                    command.CommandText = "SP_InsertTreatment";
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Add(new SqlParameter("@TrialGroupID", trialGroupID));
                                    command.Parameters.Add(new SqlParameter("@TreatmentTypeName", treatment.TreatmentTreatmentType.Name));
                                    if (treatment.TreatmentDate != null)
                                        command.Parameters.Add(new SqlParameter("@TreatmentDate", treatment.TreatmentDate));
                                    command.Parameters.Add(new SqlParameter("@TreatmentStage", treatment.TreatmentStage));
                                    command.Parameters.Add(new SqlParameter("@Comment", treatment.Comment));
                                    int treatmentID = (int)command.ExecuteScalar();

                                    command.Parameters.Clear();
                                    foreach (TreatmentProduct treatmentP in treatment.Products)
                                    {
                                        command.CommandText = "SP_InsertTreatmentProduct";
                                        command.CommandType = CommandType.StoredProcedure;
                                        command.Parameters.Add(new SqlParameter("@TreatmentID", treatmentID));
                                        command.Parameters.Add(new SqlParameter("@ProductName", treatmentP.TrtProduct.Name));
                                        command.Parameters.Add(new SqlParameter("@ProductDose", treatmentP.ProductDose));
                                        command.Parameters.Add(new SqlParameter("@ProductUnit", treatmentP.ProductUnit.Name));
                                        command.Parameters.Add(new SqlParameter("@DoseLog", treatmentP.DoseLog));
                                        command.ExecuteNonQuery();

                                        command.Parameters.Clear();
                                    }
                                }
                            }
                        }
                    }


                    transaction.Commit();
                    Console.WriteLine("Both records are written to database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                    }
                }
            }
        }
    }
}
