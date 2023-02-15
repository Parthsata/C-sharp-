private void btnlast_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!= "")
            {
               // btnSave.Text = "&Insert";
                if (rp > 0)
                {
                    rp -= 1;
                    navigate();
                }
                else
                {

                }
            }
        }
