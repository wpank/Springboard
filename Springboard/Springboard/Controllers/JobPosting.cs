protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        this.BindData();
    }
}
 
private void BindData()
{
    string strConnString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
    DataTable dt = new DataTable();
    using (SqlConnection con = new SqlConnection(strConnString))
    {
        string strQuery = "SELECT * FROM JobPostings";
        SqlCommand cmd = new SqlCommand(strQuery);
        using (SqlDataAdapter sda = new SqlDataAdapter())
        {
            cmd.Connection = con;
            con.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}


protected void Add(object sender, EventArgs e)
{
    Control control = null;
    if (GridView1.FooterRow != null)
    {
        control = GridView1.FooterRow;
    }
    else
    {
        control = GridView1.Controls[0].Controls[0];
    }
    string jobID = (control.FindControl("txtJobID") as TextBox).Text;
    string jobTitle = (control.FindControl("txtJobTitle") as TextBox).Text;
    string jobDes = (control.FindControl("txtJobDescription") as TextBox).Text;
    string jobPos = (control.FindControl("txtPosterID") as TextBox).Text;
    string jobCul = (control.FindControl("txtCulture") as TextBox).Text;
    string jobSkill = (control.FindControl("txtSkills") as TextBox).Text;
    
    string strConnString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
    using (SqlConnection con = new SqlConnection(strConnString))
    {
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO [JobPostings] VALUES(@JobID, @JobTitle, @JobDescription, @PosterID, @Culture, @SkillsRequired)";
            cmd.Parameters.AddWithValue("@JobID", jobID);
            cmd.Parameters.AddWithValue("@JobTitle", jobTitle);
            cmd.Parameters.AddWithValue("@JobDescription", jobDes);
            cmd.Parameters.AddWithValue("@PosterID", jobPos);
            cmd.Parameters.AddWithValue("@Culture", jobCul);
            cmd.Parameters.AddWithValue("@SkillsRequired", jobSkill);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    Response.Redirect(Request.Url.AbsoluteUri);
}
