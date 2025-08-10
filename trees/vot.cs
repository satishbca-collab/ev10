/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        var result = new List<IList<int>>();
        if(root == null) return result;

        var sortedList = new SortedList<int, List<int>>();

        var queue = new Queue<(TreeNode node, int vIndex)>();
        queue.Enqueue((root, 0));

        while(queue.Count > 0){
            int n = queue.Count;
            var levelDict = new Dictionary<int, List<int>>();

            for(int i = 0; i < n; i++){
                var (current, vIndex) = queue.Dequeue();

                if(!levelDict.ContainsKey(vIndex)){
                    levelDict[vIndex] = new List<int>();
                }

                levelDict[vIndex].Add(current.val);

                if(current.left != null) queue.Enqueue((current.left, vIndex-1));
                if(current.right != null) queue.Enqueue((current.right, vIndex+1));
            }

            foreach(var entry in levelDict){
                entry.Value.Sort();
                if(!sortedList.ContainsKey(entry.Key)){
                    sortedList[entry.Key] = new List<int>();
                }
                sortedList[entry.Key].AddRange(entry.Value);
            }
        }

        foreach(var column in sortedList){
            result.Add(column.Value);
        }

        return result;

        // total nodes = n
        // total columns = k
    }
}