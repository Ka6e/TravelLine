import { useNavigate, useParams } from "react-router-dom";
import { useWordStore } from "../../store/store";

export const useEditWordPageState = () => {
    const store = useWordStore((state) => state);
    const params = useParams<{ id: string }>();
    const navigate = useNavigate();

    const wordToEdit = store.words.find(word => word.id === params.id);

    const editWord = (russian: string, english: string) => {
        if (params?.id) {
            store.updateWord(params.id, russian, english);
            navigate(-1);
        }
    };

    return { wordToEdit, editWord };
};
