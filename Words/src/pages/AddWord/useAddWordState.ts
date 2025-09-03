import { useNavigate } from "react-router-dom";
import { useWordStore } from "../../store/store";

export const useAddWordPageState = () => {
    const store = useWordStore((state) => state);
    const navigate = useNavigate();

    const handleAdd = (russian: string, english: string) => {
        store.addWord(russian, english);
        navigate(-1);
    };

    return { handleAdd };
};
