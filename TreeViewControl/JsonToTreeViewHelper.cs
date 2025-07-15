using Newtonsoft.Json.Linq;

namespace velocist.WinForms.TreeViewControl {
	public static class JsonToTreeViewHelper {

		public static void PopulateTreeView(this TreeNode parentNode, JToken jsonToken) {
			try {
				if (jsonToken is JObject jsonObject) {
					foreach (var property in jsonObject.Properties()) {
						TreeNode childNode = new TreeNode(property.Name);
						parentNode.Nodes.Add(childNode);

						// Recursivamente agregar hijos
						childNode.PopulateTreeView(property.Value);
					}
				} else if (jsonToken is JArray jsonArray) {
					for (int i = 0; i < jsonArray.Count; i++) {
						TreeNode childNode = new TreeNode($"[{i}]");
						parentNode.Nodes.Add(childNode);

						// Recursivamente agregar elementos del array
						childNode.PopulateTreeView(jsonArray[i]);
					}
				} else {
					// Para valores simples, mostrar el valor en el nodo
					parentNode.Nodes.Add(new TreeNode(jsonToken.ToString()));
				}
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				//MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		public static void PopulateTreeViewInline(this TreeView tvTree, JToken jsonToken) {

			tvTree.Nodes.Clear();

			if (jsonToken.HasValues) {
				// Crear el nodo raíz
				TreeNode rootNode = new TreeNode("Root");
				tvTree.Nodes.Add(rootNode);

				// Llenar el TreeView con los datos del JSON
				rootNode.PopulateTreeViewInline(jsonToken);

			}

		}

		public static void PopulateTreeViewInline(this TreeNode parentNode, JToken jsonToken) {
			if (jsonToken is JObject jsonObject) {
				foreach (var property in jsonObject.Properties()) {
					// Si el valor es un objeto o array, llamamos recursivamente
					if (property.Value is JObject || property.Value is JArray) {
						TreeNode childNode = new TreeNode($"{property.Name}:");
						parentNode.Nodes.Add(childNode);
						childNode.PopulateTreeViewInline(property.Value);
					} else {
						// Si el valor es simple, mostrar clave y valor en el mismo nodo
						TreeNode childNode = new TreeNode($"{property.Name}: {property.Value}");
						parentNode.Nodes.Add(childNode);
					}
				}
			} else if (jsonToken is JArray jsonArray) {
				for (int i = 0; i < jsonArray.Count; i++) {
					// Si el elemento es un objeto o array, llamamos recursivamente
					if (jsonArray[i] is JObject || jsonArray[i] is JArray) {
						TreeNode childNode = new TreeNode($"[{i}]");
						parentNode.Nodes.Add(childNode);
						childNode.PopulateTreeViewInline(jsonArray[i]);
					} else {
						// Si el elemento es simple, mostrar índice y valor en el mismo nodo
						TreeNode childNode = new TreeNode($"[{i}]: {jsonArray[i]}");
						parentNode.Nodes.Add(childNode);
					}
				}
			}
		}
	}
}
