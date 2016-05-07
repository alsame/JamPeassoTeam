public static class Generator {
	public static string text(int[] a, bool answer = false){
		switch(a[1]){
			case 0:
				return a[0].ToString() + " + " + a[2].ToString() + (answer?" = "+a[6].ToString():"");
			case 1:
				return a[0].ToString() + " - " + a[2].ToString() + (answer?" = "+a[6].ToString():"");
			case 2:
				return a[0].ToString() + " x " + a[2].ToString() + (answer?" = "+a[6].ToString():"");
			default:
				return  a[0].ToString() + " / " + a[2].ToString() + (answer?" = "+a[6].ToString():"");
		}
	}
	public static System.Collections.Generic.IEnumerator<int[]> SRMD(int amount) {
		System.Random rand = new System.Random();
		for(int i = 0; i < amount; ++i) {
			int p = rand.Next(3,5);
			int[] r = new int[7]{rand.Next(0,10),rand.Next(0,4),rand.Next(1,10),0,0,0,0};
			switch (r[1]) {
				case 0: //add
					r[6] = r[5] = r[4] = r[3] = r[0] + r[2]; break;
				case 1: //sub
					r[6] = r[5] = r[4] = r[3] =  r[0] - r[2]; break;
				case 2: //mul
					r[6] = r[5] = r[4] = r[3] = r[6] = r[0] * r[2]; break;
				case 3: //div
					r[6] = r[5] = r[4] = r[3] = r[0];
					r[0] = r[0] * r[2];
					break;
			}
			while(r[3] == r[4] || r[4] == r[5] || r[5] == r[6] )
				for(int j = 3; j < 6; ++j) if(j!=p)
					r[j] = r[p] + rand.Next(-10,10);
			yield return r;
		}
	}
}
