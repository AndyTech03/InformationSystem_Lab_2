using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSystem_Lab_2
{
	public partial class BlockForm : Form, IDialogForm
	{
		private readonly FileDataSet DataSet;
		private Guid adminUuid;

		public event Action UserAction;

		public BlockForm(FileDataSet fileDataSet)
		{
			InitializeComponent();
			DataSet = fileDataSet;

			MouseMove += (object _, MouseEventArgs __) => UserAction?.Invoke();
			Click += (object _, EventArgs __) => UserAction?.Invoke();
			foreach (Control control in Controls)
				control.Click += (object _, EventArgs __) => UserAction?.Invoke();
			KeyDown += (object _, KeyEventArgs __) => UserAction?.Invoke();
			KeyPreview = true;
		}

		private void BlockOneB_Click(object sender, EventArgs e)
		{
			if (NotBlockedDGV.SelectedCells.Count == 0)
			{
				MessageBox.Show(
					"Выберите одну или несколько строк в левой таблице!", "Нет данных", 
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			HashSet<int> operatedRows = new HashSet<int>();
			foreach (DataGridViewCell cell in NotBlockedDGV.SelectedCells)
			{
				int index = cell.RowIndex;
				if (operatedRows.Contains(index))
					continue;
				operatedRows.Add(index);
				var row = NotBlockedDGV.Rows[index];
				if ((bool)row.Cells[2].Value)
				{
					MessageBox.Show("Нельзя заблокировать администратора!", "Доступ запрещён!",
					MessageBoxButtons.OK, MessageBoxIcon.Hand);
					continue;
				}
				Guid uuid = (Guid)row.Cells[0].Value;
				DataSet.BlockIfNot(uuid, $"Заблокирован администратором (uuid: {adminUuid}).",
					adminUuid, out bool denied);
				if (denied)
				{
					MessageBox.Show("Вы не обладаете правами администратора!", "Доступ запрещён!",
					MessageBoxButtons.OK, MessageBoxIcon.Hand);
					DialogResult = DialogResult.Ignore;
					return;
				}
			}
			UpdateData();
		}

		private void BlockAllB_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in NotBlockedDGV.Rows)
			{
				if ((bool)row.Cells[2].Value)
				{
					MessageBox.Show("Нельзя заблокировать администратора!", "Доступ запрещён!",
					MessageBoxButtons.OK, MessageBoxIcon.Hand);
					continue;
				}
				Guid uuid = (Guid)row.Cells[0].Value;
				DataSet.BlockIfNot(uuid, $"Заблокирован администратором (uuid: {adminUuid}).",
					adminUuid, out bool denied);
				if (denied)
				{
					MessageBox.Show("Вы не обладаете правами администратора!", "Доступ запрещён!",
					MessageBoxButtons.OK, MessageBoxIcon.Hand);
					DialogResult = DialogResult.Ignore;
					return;
				}
			}
			UpdateData();
		}

		private void UnBlockOneB_Click(object sender, EventArgs e)
		{
			if (BlockedDGV.SelectedCells.Count == 0)
			{
				MessageBox.Show(
					"Выберите одну или несколько строк в правой таблице!", "Нет данных",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			HashSet<int> operatedRows = new HashSet<int>();
			foreach (DataGridViewCell cell in BlockedDGV.SelectedCells)
			{
				int index = cell.RowIndex;
				if (operatedRows.Contains(index))
					continue;
				operatedRows.Add(index);
				var row = BlockedDGV.Rows[index]; 
				if ((bool)row.Cells[2].Value)
				{
					MessageBox.Show("Нельзя разаблокировать администратора!", "Доступ запрещён!",
					MessageBoxButtons.OK, MessageBoxIcon.Hand);
					continue;
				}
				Guid uuid = (Guid)row.Cells[0].Value;
				DataSet.UnBlockIfNot(uuid, adminUuid, out bool denied);
				if (denied)
				{
					MessageBox.Show("Вы не обладаете правами администратора!", "Доступ запрещён!",
					MessageBoxButtons.OK, MessageBoxIcon.Hand);
					DialogResult = DialogResult.Ignore;
					return;
				}
			}
			UpdateData();
		}

		private void UnBlockAllB_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in BlockedDGV.Rows)
			{
				if ((bool)row.Cells[2].Value)
				{
					MessageBox.Show("Нельзя разаблокировать администратора!", "Доступ запрещён!",
					MessageBoxButtons.OK, MessageBoxIcon.Hand);
					continue;
				}
				Guid uuid = (Guid)row.Cells[0].Value;
				DataSet.UnBlockIfNot(uuid, adminUuid, out bool denied);
				if (denied)
				{
					MessageBox.Show("Вы не обладаете правами администратора!", "Доступ запрещён!",
					MessageBoxButtons.OK, MessageBoxIcon.Hand);
					DialogResult = DialogResult.Ignore;
					return;
				}
			}
			UpdateData();
		}

		public DialogResult BeginBlockDialog(Guid adminUuid)
		{
			this.adminUuid = adminUuid;
			return ShowDialog();
		}

		private void BlockForm_Shown(object sender, EventArgs e)
		{
			if (DataSet.IsAdmin(adminUuid) == false)
			{
				MessageBox.Show("Вы не обладаете правами администратора!", "Доступ запрещён!",
				MessageBoxButtons.OK, MessageBoxIcon.Hand);
				DialogResult = DialogResult.Ignore;
				return;
			}
			UpdateData();
		}

		private void BlockedDGV_Click(object sender, EventArgs e)
		{
			if (BlockedDGV.SelectedCells.Count > 0)
			{
				DataGridViewCell selectedCell = BlockedDGV.SelectedCells[0];
				if (selectedCell.ColumnIndex != 4)
					return;
				
				DataGridViewRow selectedRow = selectedCell.OwningRow;
				MessageBox.Show(selectedRow.Cells[4].Value.ToString());
			}
		}

		private void UpdateData()
		{
			(UserData[] users, BlockData[] blockedUsers, Guid[] admins) = DataSet.GetBLockedUsers();
			BlockedUsersDS.Clear();
			var notBlockedUsersTable = BlockedUsersDS.Tables["NotBlockedUsers"];
			var blockedUsersTable = BlockedUsersDS.Tables["BlockedUsers"];
			foreach (UserData user in users)
			{
				bool isAdmin = admins.Any(a => user.uuid.Equals(a));
				if (blockedUsers.FirstOrDefault(b => b.uuid == user.uuid) is BlockData blockedUser)
				{
					DataRow blockedUserRow = blockedUsersTable.NewRow();
					blockedUserRow.ItemArray = new object[] {
						user.uuid, user.login, isAdmin,
						blockedUser.blockedAt, blockedUser.reason
					};
					blockedUsersTable.Rows.Add(blockedUserRow);
				}
				else
				{
					DataRow userRow = notBlockedUsersTable.NewRow();
					userRow.ItemArray = new object[] {
						user.uuid, user.login, isAdmin
					};
					notBlockedUsersTable.Rows.Add(userRow);
				}
			}
			BlockedDGV.ClearSelection();
			NotBlockedDGV.ClearSelection();
		}

		private void BlockForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			adminUuid = Guid.Empty;
		}
	}
}
