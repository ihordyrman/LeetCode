// 1572. Matrix Diagonal Sum
// https://leetcode.com/problems/matrix-diagonal-sum/
fn main() {
    let m1 = vec![1, 2, 3,];
    let m2 = vec![4, 5, 6,];
    let m3 = vec![7, 8, 9,];
    let matrix = vec![m1, m2, m3];

    assert_eq!(diagonal_sum(matrix), 25);
}

pub fn diagonal_sum(mat: Vec<Vec<i32>>) -> i32 {
    let len = mat.len();
    let mut sum = 0;
    let mut index = len;

    for elem in 0..len {
        index -= 1;
        if elem == index {
            sum += mat[elem][elem];
        } else {
            sum += mat[elem][elem] + mat[elem][index]
        }
    }

    sum
}
