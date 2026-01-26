// 링크 : https://www.acmicpc.net/problem/17144

#include <iostream>
#include <vector>
#include <cmath>

using namespace std;

int R, C, T;
int dx[4] = {1, 0, -1, 0};
int dy[4] = {0, 1, 0, -1};

//oooo
//oooo
//oooo
//oooo
//oooo
//oooo
//oooo

void RotateGrid(vector<vector<int>>& grid, int dir, int startY, int startX, int endY, int endX)
{
	
}

void SpreadDust(vector<vector<int>>& grid)
{
	vector<vector<int>> newGrid(R, vector<int>(C));

	for (int i = 0; i < R; i++)
	{
		for (int j = 0; j < C; j++)
		{
			if (grid[i][j] == 0 || grid[i][j] == -1)
				continue;

			vector<pair<int, int>> spreadPos;
			for (int dir = 0; dir < 4; dir++)
			{
				int nextY = i + dy[dir];
				int nextX = j + dx[dir];

				if (nextY < 0 || nextY >= R || nextX < 0 || nextX >= C ||
					grid[nextY][nextX] == -1)
					continue;

				spreadPos.push_back({ nextY, nextX });
			}

			int spreadAmount = grid[i][j] / 5;
			for (int i = 0; i < spreadPos.size(); i++)
			{
				newGrid[spreadPos[i].first][spreadPos[i].second] += spreadAmount;
			}

			grid[i][j] = grid[i][j] - spreadAmount * spreadPos.size();
			if (grid[i][j] < 0)
				grid[i][j] = 0;
		}
	}
}

int main()
{
	cin >> R >> C >> T;

	vector<vector<int>> grid(R, vector<int>(C));
	vector<pair<int, int>> cleanerPos;
	for (int i = 0; i < R; i++)
	{
		for (int j = 0; j < C; j++)
		{
			int number; cin >> number;
			grid[i][j] = number;

			if (number == -1)
				cleanerPos.push_back({ i, j });
		}
	}

	for (int t = 0; t < T; t++)
	{
		SpreadDust(grid);

		int cleanerUpY = cleanerPos[0].first < cleanerPos[1].first ? cleanerPos[0].first : cleanerPos[1].first;
		
		// cleanerUpY좌표를 기준으로 반시계방향 회전.
		RotateGrid(grid, -1, 0, 0, cleanerUpY, C);

		// cleanerDownY좌표를 기준으로 시계방향 회전.
		RotateGrid(grid, 1, cleanerUpY + 1, 0, R - 1, C);
	}
}