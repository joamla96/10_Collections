using System;
using System.Collections.Generic;

namespace _10_Collections {
	internal class Portfolio : IAsset {
		private List<IAsset> assets;

		public List<IAsset> Assets {
			get { return this.assets; }
			//set { throw new NotSupportedException("Unable to add an asset to the returned collection. Collection is ReadOnly"); }
		}

		public Portfolio(List<IAsset> stocks) {
			this.assets = stocks;
		}

		public Portfolio() {
			assets = new List<IAsset>();
		}

		public double GetTotalValue() {
			double Sum = 0;

			foreach (IAsset stock in assets) {
				Sum += stock.GetValue();
			}

			return Sum;
		}

		public void AddAsset(IAsset Stock) {
			this.assets.Add(Stock);
		}

		public string GetName() {
			throw new NotImplementedException();
		}

		public double GetValue() {
			throw new NotImplementedException();
		}

		internal IList<IAsset> GetAssets() {
			return this.Assets;
		}

		internal IAsset GetAssetByName(string Sym) {
			IAsset ReturnAsset = null;
			foreach(IAsset Asset in assets) {
				if (Asset.GetName() == Sym) {
					ReturnAsset = Asset; break;
				}
			}

			return ReturnAsset;
		}

		internal IList<IAsset> GetAssetsSortedByName() {
			assets.Sort(new StockNameComparator());
			return assets;
		}

		internal IList<IAsset> GetAssetsSortedByValue() {
			assets.Sort(new StockValueComparator());
			return assets;
		}
	}
}