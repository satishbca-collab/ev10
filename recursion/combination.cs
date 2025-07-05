public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var result = new List<IList<int>>();
        Helper(candidates, target, 0, result, new List<int>());
        return result;
    }

    private void Helper(int[] candidates, int target, int startIndex, IList<IList<int>> result, List<int> current){
        if(target < 0){
            return;
        }
        if(target == 0){
            result.Add(new List<int>(current));
            return;
        }

        for(int i = startIndex; i < candidates.Length; i++){
            current.Add(candidates[i]);
            Helper(candidates, target-candidates[i], i, result, current);
            current.RemoveAt(current.Count-1);
        }
    }
}